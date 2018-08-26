using System;
using System.Collections.Generic;

namespace Ametista.Core.ValueObjects
{
    public sealed class Money
    {
        public Money(decimal amount, string currencyCode)
        {
            Amount = amount;
            CurrencyCode = currencyCode ?? throw new ArgumentNullException(nameof(currencyCode));
        }

        public decimal Amount { get; private set; }
        public string CurrencyCode { get; private set; }

        public override bool Equals(object obj)
        {
            var currency = obj as Money;
            return currency != null &&
                   Amount == currency.Amount &&
                   CurrencyCode == currency.CurrencyCode;
        }

        public override int GetHashCode()
        {
            var hashCode = -1731499236;
            hashCode = hashCode * -1521134295 + Amount.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CurrencyCode);
            return hashCode;
        }
    }
}