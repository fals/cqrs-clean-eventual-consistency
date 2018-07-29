using Ametista.Core.Entity;
using Ametista.Core.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ametista.Infrastructure.Persistence.Repository
{
    public class MinerRepository : IMinerRepository
    {
        private readonly WriteDbContext context;

        public MinerRepository(WriteDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> Add(Miner entity)
        {
            context.Miners.Add(entity);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Miner entity)
        {
            context.Miners.Remove(entity);

            return await context.SaveChangesAsync() > 0;
        }

        public IQueryable<Miner> FindAll()
        {
            return context.Miners.AsQueryable();
        }

        public async Task<Miner> FindAsync(Guid id)
        {
            return await context.Miners.FindAsync(id);
        }

        public async Task<bool> Update(Miner entity)
        {
            context.Miners.Update(entity);

            return await context.SaveChangesAsync() > 0;
        }
    }
}
