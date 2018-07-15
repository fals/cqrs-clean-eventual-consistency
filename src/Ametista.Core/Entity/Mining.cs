using Ametista.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Core.Entity
{
    public class Mining : IAggregate
    {
        public virtual Guid Id { get; private set; }
        public virtual Miner Miner { get; private set; }
        public virtual DateTime Date { get; private set; }
        public virtual Gemstone Gemstone { get; set; }
        public virtual int Quantity { get; private set; }

    }
}
