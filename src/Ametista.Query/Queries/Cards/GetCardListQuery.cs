using Ametista.Query.QueryModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Query.Queries
{
    public class GetCardListQuery : IQuery<IEnumerable<CardListQueryModel>>
    {
        public string CardHolder { get; set; }
        public DateTime? ChargeDate { get; set; }
        public string Number { get; set; }
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 1;
    }
}
