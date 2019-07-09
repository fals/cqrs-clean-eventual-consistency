using Ametista.Core.Transactions;
using Ametista.Query.QueryModel;

namespace Ametista.Query.Materializers
{
    public interface ITransactionListQueryModelMaterializer: IMaterializer<TransactionListQueryModel, Transaction, CardListQueryModel>
    {

    }

    public class TransactionListQueryModelMaterializer : ITransactionListQueryModelMaterializer
    {
        public TransactionListQueryModel Materialize(Transaction source1, CardListQueryModel source2)
        {
            return new TransactionListQueryModel()
            {
                Id = source1.Id,
                Amount = source1.Charge.Amount,
                ChargeDate = source1.ChargeDate,
                CardHolder = source2.CardHolder,
                CardNumber = source2.Number,
                CurrencyCode = source1.Charge.CurrencyCode,
                UniqueId = source1.UniqueId
            };
        }
    }
}
