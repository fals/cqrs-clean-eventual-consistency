using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ametista.Api.Model
{
    public class GetTransactionsRequest
    {
        public decimal Amount { get; set; }
        public string CardHolder { get; set; }
        public string CardNumber { get; set; }
        public DateTime ChargeDate { get; set; }
        public int Offset { get; set; } = 1;
        public int Limit { get; set; } = 10;
    }
}
