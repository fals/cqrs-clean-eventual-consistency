using Ametista.Core.Interfaces;
using Ametista.Core.ValueObjects;
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
        public WorkerRegister RegisterNumber { get; private set; }
    }
}
