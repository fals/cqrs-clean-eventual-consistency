using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Core.ValueObjects
{
    public sealed class WorkerRegister
    {
        public WorkerRegister(string countryCode, int number)
        {
            CountryCode = countryCode ?? throw new ArgumentNullException(nameof(countryCode));
            Number = number <= 0 ? throw new ArgumentNullException(nameof(number)) : number.ToString("D4");
        }

        public string CountryCode { get; private set; }
        public string Number { get; private set; }

        public override bool Equals(object obj)
        {
            var register = obj as WorkerRegister;
            return register != null &&
                   CountryCode == register.CountryCode &&
                   Number == register.Number;
        }

        public override int GetHashCode()
        {
            var hashCode = 1782120216;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CountryCode);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Number);
            return hashCode;
        }

        public override string ToString()
        {
            return CountryCode + Number;
        }
    }
}
