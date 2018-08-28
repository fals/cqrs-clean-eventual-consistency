using System;

namespace Ametista.Core.Events
{
    public class NewTransactionCreatedEvent : Event
    {
        public NewTransactionCreatedEvent(Guid transactionId)
        {
            TransactionId = transactionId;
            Name = (nameof(NewTransactionCreatedEvent));
        }

        public Guid TransactionId { get; set; }
    }
}