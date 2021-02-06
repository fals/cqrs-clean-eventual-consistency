using System;

namespace Ametista.Api.Endpoints.GetCardList
{
    public class GetCardListResponse
    {
        public string CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime? HighestChargeDate { get; set; }
        public decimal? HighestTransactionAmount { get; set; }
        public Guid? HighestTransactionId { get; set; }
        public Guid Id { get; set; }
        public string Number { get; set; }
    }
}
