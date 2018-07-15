using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Core.ValueObjects
{
    public sealed class GemstonePrice
    {
        public GemstonePrice(string currency, decimal amount)
        {
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
            Amount = amount;
        }

        public string Currency { get; set; }
        public decimal Amount { get; set; }

        public override bool Equals(object obj)
        {
            var price = obj as GemstonePrice;
            return price != null &&
                   Currency == price.Currency &&
                   Amount == price.Amount;
        }

        public override int GetHashCode()
        {
            var hashCode = 621650223;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Currency);
            hashCode = hashCode * -1521134295 + Amount.GetHashCode();
            return hashCode;
        }
    }
}
