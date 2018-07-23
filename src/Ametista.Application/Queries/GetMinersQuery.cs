using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Application.Queries
{
    public class GetMinersQuery
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int TotalGems { get; set; }
        public decimal TotalProfitGems { get; set; }
        public string RegisterNumber { get; set; }
    }
}
