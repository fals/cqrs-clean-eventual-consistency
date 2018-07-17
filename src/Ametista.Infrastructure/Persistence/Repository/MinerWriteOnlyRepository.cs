using Ametista.Core.Entity;
using Ametista.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ametista.Infrastructure.Persistence.Repository
{
    public class MinerWriteOnlyRepository : IWriteOnlyRepository<Miner>
    {
        private readonly WriteDbContext context;

        public MinerWriteOnlyRepository(WriteDbContext context)
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

        public async Task<Miner> Find(Guid id)
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
