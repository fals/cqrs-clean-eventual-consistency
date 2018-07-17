using Ametista.Core.Entity;
using Ametista.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ametista.Infrastructure.Persistence.Repository
{
    public class MiningWriteOnlyRepository : IWriteOnlyRepository<Mining>
    {
        private readonly WriteDbContext context;

        public MiningWriteOnlyRepository(WriteDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> Add(Mining entity)
        {
            context.Minings.Add(entity);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Mining entity)
        {
            context.Minings.Remove(entity);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<Mining> Find(Guid id)
        {
            return await context.Minings.FindAsync(id);
        }

        public async Task<bool> Update(Mining entity)
        {
            context.Minings.Update(entity);

            return await context.SaveChangesAsync() > 0;
        }
    }
}
