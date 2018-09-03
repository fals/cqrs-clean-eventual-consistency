using Ametista.Core.Entity;

namespace Ametista.Core.Events
{
    public class TransactionCreatedEvent : Event
    {
        public Transaction Data { get; set; }
    
        public TransactionCreatedEvent(Transaction transaction)
        {
            Data = transaction;
            Name = (nameof(TransactionCreatedEvent));
        }
    }
}