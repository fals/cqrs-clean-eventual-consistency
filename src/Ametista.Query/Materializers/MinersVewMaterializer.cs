using Ametista.Infrastructure.Queries;
using System.Linq;
using System.Threading.Tasks;
using System;
using Ametista.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using Ametista.Queries;
using Ametista.Core.Repository;
using Ametista.Core.Events;

namespace Ametista.Infrastructure.Materializers
{
    public class MinersMaterializer : IMaterializer<MaterializeMinersQueryEvent>
    {
        private readonly IMinerRepository minerRepository;
        private readonly IMiningRepository miningRepository;
        private readonly ReadDbContext readDbContext;

        public MinersMaterializer(IMinerRepository minerRepository, IMiningRepository miningRepository, ReadDbContext readDbContext)
        {
            this.minerRepository = minerRepository ?? throw new ArgumentNullException(nameof(minerRepository));
            this.miningRepository = miningRepository ?? throw new ArgumentNullException(nameof(miningRepository));
            this.readDbContext = readDbContext ?? throw new ArgumentNullException(nameof(readDbContext));
        }

        public async Task<bool> Materialize(MaterializeMinersQueryEvent e)
        {
            var miner = await minerRepository.FindAsync(e.MinerId);

            int totalGems = miningRepository
                .FindAll()
                .Where(x => x.Miner.Id == e.Id)
                .Sum(x => x.Quantity);

            var totalProfitGems = miningRepository
               .FindAll()
               .Where(x => x.Miner.Id == e.Id)
               .Sum(x => x.Gemstone.Price);

            var mostFoundGem = miningRepository
                .FindAll()
                .Where(x => x.Miner.Id == e.Id)
                .GroupBy(x => new { x.Gemstone.Id, x.Gemstone.Name })
                .Select(x => new
                {
                    GemstoneName = x.Key.Name,
                    GemstoneId = x.Key.Id,
                    Qùantity = x.Sum(y => y.Quantity)

                })
                .OrderByDescending(x => x.Qùantity)
                .FirstOrDefault();

            var queryModel = new MinersViewQueryModel()
            {
                Id = miner.Id,
                RegisterNumber = miner.RegisterNumber.ToString(),
                BirthDate = miner.BirthDate,
                FullName = miner.ToString(),
                TotalGems = totalGems,
                TotalProfitGems = totalProfitGems,
                MostFoundGemstoneId = mostFoundGem?.GemstoneId,
                MostFoundGemstoneName = mostFoundGem?.GemstoneName,
                TotalQuantityMostFoundGem = mostFoundGem?.Qùantity
            };

            var result = await readDbContext.MinersMaterializedView.ReplaceOneAsync(
               filter: new BsonDocument("Id", miner.Id),
               options: new UpdateOptions { IsUpsert = true },
               replacement: queryModel);

            return result.ModifiedCount > 0;
        }
    }
}
