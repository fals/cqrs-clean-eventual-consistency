using Ametista.Query.Abstractions;
using Ametista.Query.QueryModel;
using System;
using System.Collections.Generic;

namespace Ametista.Query.Queries
{
    public class GetTransactionListQuery : IQuery<IEnumerable<TransactionListQueryModel>>
    {
        public decimal? BetweenAmount { get; set; }
        public string CardHolder { get; set; }
        public string CardNumber { get; set; }
        public DateTimeOffset? ChargeDate { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
