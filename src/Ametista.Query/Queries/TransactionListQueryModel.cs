using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Query.Queries
{
    public class TransactionListQueryModel : IQueryModel
    {
        public object Id { get; set; }
        public decimal Amount { get;  set; }
        public string CurrencyCode { get;  set; }
        public string CardNumber { get;  set; }
        public string CardHolder { get;  set; }
        public string UniqueId { get;  set; }
        public DateTimeOffset ChargeDate { get;  set; }
    }
}
