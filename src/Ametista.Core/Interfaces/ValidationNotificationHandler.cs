using System.Collections.Generic;

namespace Ametista.Core
{
    public class ValidationNotificationHandler
    {
        public virtual IReadOnlyCollection<ValidationNotification> Notifications => _notifications.AsReadOnly();

        private readonly List<ValidationNotification> _notifications = new List<ValidationNotification>();

        public void AddNotification(string code, string message)
        {
            var notification = new ValidationNotification(code, message);

            _notifications.Add(notification);
        }
    }
}
