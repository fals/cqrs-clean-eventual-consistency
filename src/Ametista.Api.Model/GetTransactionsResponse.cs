using System;

namespace Ametista.Api.Model
{
    public class GetTransactionsResponse
    {
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string CardNumber { get; set; }
        public string CardHolder { get; set; }
        public string UniqueId { get; set; }
        public DateTimeOffset ChargeDate { get; set; }
    }
}
