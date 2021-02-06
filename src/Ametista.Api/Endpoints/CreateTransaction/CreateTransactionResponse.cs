using System;

namespace Ametista.Api.Endpoints.CreateTransaction
{
    public class CreateTransactionResponse
    {
        public Guid Id { get; set; }
        public Guid CardId { get; set; }
        public DateTimeOffset ChargeDate { get; set; }
        public string UniqueId { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
    }
}