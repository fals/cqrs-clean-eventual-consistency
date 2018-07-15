using Ametista.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Application.Queries
{
    public class MinersQueryModel : IQueryModel
    {
        public Guid id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int TotalProspectedGems { get; set; }
        public decimal TotalGems { get; set; }
        public string MyProperty { get; set; }
        public Guid MostFoundGemstoneId { get; set; }
        public string MostFoundGemstoneName { get; set; }
        public string RegisterNumber { get; set; }
    }
}
