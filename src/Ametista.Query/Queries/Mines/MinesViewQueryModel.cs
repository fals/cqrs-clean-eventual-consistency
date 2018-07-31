using Ametista.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Application.Queries
{
    public class MinesViewQueryModel : IQueryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ManagersId{ get; set; }
        public string ManagersName { get; set; }
        public decimal TotalAmountGems { get; set; }
        public Guid MostFoundGemstoneId { get; set; }
        public string MostFoundGemstoneName { get; set; }
        public int TotalWorkers { get; set; }
    }
}
