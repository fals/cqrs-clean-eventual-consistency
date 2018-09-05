using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ametista.Api.Model
{
    public class GetCardListRequest
    {
        public string CardHolder { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Number { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
