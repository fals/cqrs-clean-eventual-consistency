using Ametista.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace Ametista.Core.Transactions
{
    public class Transaction : IAggregateRoot
    {
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

        public Guid CardId { get; private set; }

        public Money Charge { get; private set; }

        public DateTimeOffset ChargeDate { get; private set; }

        public Guid Id { get; private set; }

        public string UniqueId { get; private set; }

        public bool Valid { get; private set; }

        public static Transaction CreateTransactionForCard(Guid cardGuid, string uniqueId, DateTimeOffset chargeDate, Money charge)
        {
            return new Transaction(cardGuid, uniqueId, chargeDate, charge);
        }

        public override bool Equals(object obj)
        {
            var transaction = obj as Transaction;
            return transaction != null &&
                   UniqueId == transaction.UniqueId;
        }

        public override int GetHashCode()
        {
            return -401120461 + EqualityComparer<string>.Default.GetHashCode(UniqueId);
        }

        public void Validate(ValidationNotificationHandler notificationHandler)
        {
            throw new NotImplementedException();
        }
    }
}