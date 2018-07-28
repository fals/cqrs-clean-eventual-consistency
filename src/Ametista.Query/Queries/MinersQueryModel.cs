using Ametista.Core;
using System;

namespace Ametista.Queries
{
    public class MinersQueryModel : IQueryModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int TotalGems { get; set; }
        public decimal TotalProfitGems { get; set; }
        public Guid? MostFoundGemstoneId { get; set; }
        public string MostFoundGemstoneName { get; set; }
        public int? TotalQuantityMostFoundGem { get; set; }
        public string RegisterNumber { get; set; }
    }
}
