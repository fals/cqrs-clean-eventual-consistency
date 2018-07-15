using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Core.ValueObjects
{
    public sealed class Name
    {
        public Name(string firstName, string surName)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            SurName = surName ?? throw new ArgumentNullException(nameof(surName));
        }

        public string FirstName { get; private set; }
        public string SurName { get; private set; }

        public override bool Equals(object obj)
        {
            var name = obj as Name;
            return name != null &&
                   FirstName == name.FirstName &&
                   SurName == name.SurName;
        }

        public override int GetHashCode()
        {
            var hashCode = 322899472;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SurName);
            return hashCode;
        }

        public override string ToString()
        {
            return string.Concat(SurName, ", ", FirstName);
        }
    }
}
