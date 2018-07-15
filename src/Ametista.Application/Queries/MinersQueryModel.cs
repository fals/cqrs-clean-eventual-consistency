using Ametista.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Application.Queries
{
    public class MinersQueryModel : IQueryModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int TotalMiningGems { get; set; }
        public decimal TotalAmoutGems { get; set; }
        public Guid? MostFoundGemstoneId { get; set; }
        public string MostFoundGemstoneName { get; set; }
        public int? TotalQuantityMostFoundGem { get; set; }
        public string RegisterNumber { get; set; }
    }
}
