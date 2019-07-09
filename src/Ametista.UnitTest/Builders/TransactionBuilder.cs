using Ametista.Core;
using Ametista.Core.Shared;
using Ametista.Core.Transactions;
using System;

namespace Ametista.UnitTest.Builders
{
    public class TransactionBuilder : IBuilder<Transaction>
    {
        private Guid cardId;

        private Money charge;

        private DateTimeOffset chargeDate;

        private string uniqueId;

        public TransactionBuilder ForCard(Guid id)
        {
            cardId = id;

            return this;
        }

        public TransactionBuilder ContainingChargeAmount(Money charge)
        {
            this.charge = charge;

            return this;
        }

        public TransactionBuilder ChargedAt(DateTimeOffset date)
        {
            this.chargeDate = date;

            return this;
        }

        public TransactionBuilder HavingUniqueId(string uniqueId)
        {
            this.uniqueId = uniqueId;

            return this;
        }

        public Transaction Build()
        {
            return Transaction.CreateTransactionForCard(cardId, uniqueId, chargeDate, charge);
        }
    }
}
