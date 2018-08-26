using Ametista.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace Ametista.Core.Entity
{
    public class Card : IAggregate
    {
        protected Card()
        {
        }

        private Card(string number, string cardHolder, DateTime expirationDate)
        {
            Id = Guid.NewGuid();
            Number = number ?? throw new ArgumentNullException(nameof(number));
            CardHolder = cardHolder ?? throw new ArgumentNullException(nameof(cardHolder));
            ExpirationDate = expirationDate;
        }

        public string CardHolder { get; private set; }

        public DateTime ExpirationDate { get; private set; }

        public Guid Id { get; private set; }

        public string Number { get; private set; }

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
    }
}