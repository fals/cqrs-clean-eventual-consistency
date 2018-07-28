using Ametista.Core.Entity;
using Ametista.Core.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ametista.Infrastructure.Persistence.Repository
{
    public class GemstoneRepository : IGemstoneRepository
    {
        private readonly WriteDbContext context;

        public GemstoneRepository(WriteDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> Add(Gemstone entity)
        {
            context.Gemstones.Add(entity);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Gemstone entity)
        {
            context.Gemstones.Remove(entity);

            return await context.SaveChangesAsync() > 0;
        }

        public IQueryable<Gemstone> FindAll()
        {
            return context.Gemstones.AsQueryable();
        }

        public async Task<Gemstone> FindAsync(Guid id)
        {
            return await context.Gemstones.FindAsync(id);
        }

        public async Task<bool> Update(Gemstone entity)
        {
            context.Gemstones.Update(entity);

            return await context.SaveChangesAsync() > 0;
        }
    }
}
