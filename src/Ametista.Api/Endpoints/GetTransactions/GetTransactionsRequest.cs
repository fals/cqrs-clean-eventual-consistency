using System;

namespace Ametista.Api.Endpoints.GetTransactions
{
    public class GetTransactionsRequest
    {
        public decimal? BetweenAmount { get; set; }
        public string CardHolder { get; set; }
        public string CardNumber { get; set; }
        public DateTime? ChargeDate { get; set; }
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 1;
    }
}
