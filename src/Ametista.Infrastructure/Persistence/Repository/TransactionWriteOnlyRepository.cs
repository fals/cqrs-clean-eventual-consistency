using Ametista.Core.Entity;
using Ametista.Core.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ametista.Infrastructure.Persistence.Repository
{
    public class TransactionWriteOnlyRepository : ITransactionWriteOnlyRepository
    {
        private readonly WriteDbContext writeDbContext;

        public TransactionWriteOnlyRepository(WriteDbContext writeDbContext)
        {
            this.writeDbContext = writeDbContext ?? throw new ArgumentNullException(nameof(writeDbContext));
        }

        public async Task<bool> Add(Transaction entity)
        {
            writeDbContext.Transactions.Add(entity);
            return await writeDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Transaction entity)
        {
            writeDbContext.Transactions.Remove(entity);
            return await writeDbContext.SaveChangesAsync() > 0;
        }

        public IQueryable<Transaction> FindAll()
        {
            return writeDbContext.Transactions;
        }

        public async Task<Transaction> FindAsync(Guid id)
        {
            return await writeDbContext.Transactions.FindAsync(id);
        }

        public async Task<bool> Update(Transaction entity)
        {
            writeDbContext.Transactions.Update(entity);
            return await writeDbContext.SaveChangesAsync() > 0;
        }
    }
}