using Ametista.Application.Events;
using Ametista.Infrastructure.Persistence;
using Ametista.Infrastructure.Queries;
using System.Linq;
using Ametista.Application.Queries;
using System.Threading.Tasks;
using System;
using Ametista.Core;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Ametista.Infrastructure.Materializers
{
    public class MinersMaterializer : IMaterialize<MaterializeMinersQueryEvent>
    {
        private readonly WriteDbContext writeDbContext;
        private readonly ReadDbContext readDbContext;

        public MinersMaterializer(WriteDbContext writeDbContext, ReadDbContext readDbContext)
        {
            this.writeDbContext = writeDbContext ?? throw new ArgumentNullException(nameof(writeDbContext));
            this.readDbContext = readDbContext ?? throw new ArgumentNullException(nameof(readDbContext));
        }

        public async Task<bool> Materialize(MaterializeMinersQueryEvent e)
        {
            var miner = writeDbContext
                .Miners
                .Find(e.Id);

            var totalMiningGems = writeDbContext
                .Minings
                .Where(x => x.Miner.Id == e.Id)
                .Sum(x => x.Quantity);

            var totalAmountGems = writeDbContext
               .Minings
               .Where(x => x.Miner.Id == e.Id)
               .Sum(x => x.Gemstone.Price);

            var mostFoundGem = writeDbContext
                .Minings
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

            var queryModel = new MinersQueryModel()
            {
                Id = miner.Id,
                RegisterNumber = miner.RegisterNumber.ToString(),
                BirthDate = miner.BirthDate,
                FullName = miner.ToString(),
                TotalMiningGems = totalMiningGems,
                TotalAmoutGems = totalAmountGems,
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
