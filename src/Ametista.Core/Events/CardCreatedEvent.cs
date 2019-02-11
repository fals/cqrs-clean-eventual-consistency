using Ametista.Core.Entities.Cards;
using System;

namespace Ametista.Core.Events
{
    public class CardCreatedEvent : Event
    {
        public Card Data { get; set; }
        public CardCreatedEvent(Card card)
        {
            Data = card;
            Name = (nameof(CardCreatedEvent));
        }
    }
}