using System;

namespace Ametista.Query.QueryModel
{
    public class CardListQueryModel : IQueryModel
    {
        public string CardHolder { get; set; }
        public decimal? CurrentMonthTotal { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime? HighestChargeDate { get; set; }
        public decimal? HighestTransactionAmount { get; set; }
        public Guid? HighestTransactionId { get; set; }
        public Guid Id { get; set; }
        public decimal? LastMonthTotal { get; set; }
        public string Number { get; set; }
    }
}