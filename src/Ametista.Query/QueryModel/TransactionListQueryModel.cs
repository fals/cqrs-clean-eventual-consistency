using Ametista.Query.Abstractions;
using System;

namespace Ametista.Query.QueryModel
{
    public class TransactionListQueryModel : IQueryModel
    {
        public object Id { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string CardNumber { get; set; }
        public string CardHolder { get; set; }
        public string UniqueId { get; set; }
        public DateTimeOffset ChargeDate { get; set; }
    }
}
