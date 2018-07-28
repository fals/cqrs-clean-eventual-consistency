using Ametista.Core.Entity;
using Ametista.Core.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ametista.Infrastructure.Persistence.Repository
{
    public class MiningRepository : IMiningRepository
    {
        private readonly WriteDbContext context;

        public MiningRepository(WriteDbContext context)
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

        public IQueryable<Mining> FindAll()
        {
            return context.Minings.AsQueryable();
        }

        public async Task<Mining> FindAsync(Guid id)
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
