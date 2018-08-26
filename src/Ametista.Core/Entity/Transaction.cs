using Ametista.Core.Interfaces;
using Ametista.Core.ValueObjects;
using System;

namespace Ametista.Core.Entity
{
    public class Transaction : IEntity
    {
        public static Transaction CreateTransactionForCard(Guid cardGuid, string uniqueId, DateTimeOffset chargeDate, Money charge)
        {
            return new Transaction(cardGuid, uniqueId, chargeDate, charge);
        }

        protected Transaction()
        {
        }

        private Transaction(Guid cardGuid, string uniqueId, DateTimeOffset chargeDate, Money charge)
        {
            Id = Guid.NewGuid();
            CardId = cardGuid;
            UniqueId = uniqueId ?? throw new ArgumentNullException(nameof(uniqueId));
            ChargeDate = chargeDate;
            Charge = charge ?? throw new ArgumentNullException(nameof(charge));
        }

        public Guid Id { get; private set; }
        public Guid CardId { get; private set; }
        public string UniqueId { get; private set; }
        public DateTimeOffset ChargeDate { get; private set; }
        public Money Charge { get; private set; }
    }
}