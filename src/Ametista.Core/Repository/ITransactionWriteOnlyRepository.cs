using Ametista.Core.Entities.Transactions;
using Ametista.Core.Interfaces;

namespace Ametista.Core.Repository
{
    public interface ITransactionWriteOnlyRepository : IWriteOnlyRepository<Transaction>
    {
    }
}