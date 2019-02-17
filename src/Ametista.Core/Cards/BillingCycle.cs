using System;

namespace Ametista.Core.Cards
{
    public sealed class BillingCycle
    {
        public int DueDay { get; private set; }
        public int Range { get; private set; }
    }
}
