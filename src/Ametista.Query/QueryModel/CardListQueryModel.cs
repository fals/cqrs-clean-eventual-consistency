using Ametista.Query.Abstractions;
using System;

namespace Ametista.Query.QueryModel
{
    public class CardListQueryModel : IQueryModel
    {
        public string CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTimeOffset? HighestChargeDate { get; set; }
        public decimal? HighestTransactionAmount { get; set; }
        public Guid? HighestTransactionId { get; set; }
        public Guid Id { get; set; }
        public string Number { get; set; }
        public int TransactionCount { get; set; }
    }
}