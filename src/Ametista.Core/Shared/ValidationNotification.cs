using System;
using System.Collections.Generic;

namespace Ametista.Core
{
    public class ValidationNotification : IEquatable<ValidationNotification>
    {
        public ValidationNotification(string code, string message)
        {
            Code = code;
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }

        public string Code { get; private set; }
        public string Message { get; private set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as ValidationNotification);
        }

        public bool Equals(ValidationNotification other)
        {
            return other != null &&
                   Code.Equals(other.Code) &&
                   Message == other.Message;
        }

        public override int GetHashCode()
        {
            var hashCode = -1809243720;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Code);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Message);
            return hashCode;
        }

        public static bool operator ==(ValidationNotification notification1, ValidationNotification notification2)
        {
            return EqualityComparer<ValidationNotification>.Default.Equals(notification1, notification2);
        }

        public static bool operator !=(ValidationNotification notification1, ValidationNotification notification2)
        {
            return !(notification1 == notification2);
        }
    }
}
