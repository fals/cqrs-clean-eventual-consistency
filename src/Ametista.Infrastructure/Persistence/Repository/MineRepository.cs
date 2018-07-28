using Ametista.Core.Entity;
using Ametista.Core.Interfaces;
using Ametista.Core.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ametista.Infrastructure.Persistence.Repository
{
    public class MineRepository : IMineRepository
    {
        private readonly WriteDbContext context;

        public MineRepository(WriteDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> Add(Mine entity)
        {
            context.Mines.Add(entity);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Mine entity)
        {
            context.Mines.Remove(entity);

            return await context.SaveChangesAsync() > 0;
        }

        public IQueryable<Mine> FindAll()
        {
            return context.Mines.AsQueryable();
        }

        public async Task<Mine> FindAsync(Guid id)
        {
            return await context.Mines.FindAsync(id);
        }

        public async Task<bool> Update(Mine entity)
        {
            context.Mines.Update(entity);

            return await context.SaveChangesAsync() > 0;
        }
    }
}
