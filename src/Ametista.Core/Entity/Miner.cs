using Ametista.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Core.Entity
{
    public class Miner : IAggregate
    {
        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public DateTime BirthDate { get; private set; }
    }
}
