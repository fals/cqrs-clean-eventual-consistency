using System;

namespace Ametista.Api.Model
{
    public class GetTransactionsRequest
    {
        public decimal? BetweenAmount { get; set; }
        public string CardHolder { get; set; }
        public string CardNumber { get; set; }
        public DateTime? ChargeDate { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
