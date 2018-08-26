using Ametista.Core.Entity;
using Ametista.Core.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ametista.Infrastructure.Persistence.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly WriteDbContext writeDbContext;

        public CardRepository(WriteDbContext writeDbContext)
        {
            this.writeDbContext = writeDbContext ?? throw new ArgumentNullException(nameof(writeDbContext));
        }

        public async Task<bool> Add(Card entity)
        {
            writeDbContext.Cards.Add(entity);
            return await writeDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Card entity)
        {
            writeDbContext.Cards.Remove(entity);
            return await writeDbContext.SaveChangesAsync() > 0;
        }

        public IQueryable<Card> FindAll()
        {
            return writeDbContext.Cards;
        }

        public async Task<Card> FindAsync(Guid id)
        {
            return await writeDbContext.Cards.FindAsync(id);
        }

        public async Task<bool> Update(Card entity)
        {
            writeDbContext.Cards.Update(entity);
            return await writeDbContext.SaveChangesAsync() > 0;
        }
    }
}
