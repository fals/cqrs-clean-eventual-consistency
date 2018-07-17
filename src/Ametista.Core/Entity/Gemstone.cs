using Ametista.Core.Interfaces;
using System;

namespace Ametista.Core.Entity
{
    public class Gemstone : IAggregate
    {
        protected Gemstone()
        {
        }

        public virtual Guid Id { get; private set; }
        public virtual string Name { get; private set; }
        public virtual string ScientificName { get; private set; }
        public virtual decimal Price { get; private set; }

        public static Gemstone CreateNew(string name, string scientificName, decimal price)
        {
            return new Gemstone() { Id = Guid.NewGuid(), Name = name, ScientificName = scientificName, Price = price };
        }
    }
}
