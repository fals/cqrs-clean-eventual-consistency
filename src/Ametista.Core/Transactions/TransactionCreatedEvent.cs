namespace Ametista.Core.Transactions
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