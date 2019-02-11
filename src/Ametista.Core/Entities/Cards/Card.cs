using Ametista.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ametista.Core.Entities.Cards
{
    public class Card : IAggregateRoot
    {
        protected Card()
        {
        }

        private Card(string number, string cardHolder, DateTime expirationDate)
        {
            Id = Guid.NewGuid();
            Number = number;
            CardHolder = cardHolder;
            ExpirationDate = expirationDate;
        }

        public string CardHolder { get; private set; }

        public DateTime ExpirationDate { get; private set; }

        public Guid Id { get; private set; }

        public string Number { get; private set; }

        public bool Valid { get; private set; }

        public static Card CreateNewCard(string number, string cardHolder, DateTime expirationDate)
        {
            return new Card(number, cardHolder, expirationDate);
        }

        public override bool Equals(object obj)
        {
            var card = obj as Card;
            return card != null &&
                   Number == card.Number;
        }

        public override int GetHashCode()
        {
            var hashCode = 1924120557;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Number);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CardHolder);
            hashCode = hashCode * -1521134295 + ExpirationDate.GetHashCode();
            return hashCode;
        }

        public void Validate(ValidationNotificationHandler notificationHandler)
        {
            var validator = new CardValidator(notificationHandler);

            validator.Validate(this);

            Valid = !notificationHandler.Notifications.Any();
        }
    }
}