using Ametista.Core.Interfaces;
using System;

namespace Ametista.Core.Entity
{
    public class Gemstone : IEntity
    {
        protected Gemstone()
        {
        }

        public virtual Guid Id { get; private set; }
        public virtual string Name { get; private set; }
        public virtual string ScientificName { get; private set; }

    }
}
