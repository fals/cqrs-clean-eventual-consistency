using Ametista.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Application.Queries
{
    public class MinesQuery : IQuery<MinesQueryModel>
    {
        public string Name { get; set; }
        public string ManagersName { get; set; }
        public Decimal Profit { get; set; }
    }
}
