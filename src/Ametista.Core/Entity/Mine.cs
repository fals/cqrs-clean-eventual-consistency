using Ametista.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Core.Entity
{
    public class Mine : IAggregate
    {
        public virtual Guid Id { get; private set; }
        public virtual string Name { get; private set; }

    }
}
