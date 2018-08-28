using System;

namespace Ametista.Core.Events
{
    public class NewTransactionCreatedEvent : Event
    {
        public NewTransactionCreatedEvent(Guid transactionId)
        {
            TransactionId = transactionId;
            Name = "_" + (nameof(NewTransactionCreatedEvent));
        }

        public Guid TransactionId { get; set; }
    }
}