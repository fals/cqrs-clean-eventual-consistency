using System;

namespace Ametista.Core.Events
{
    public class NewCardCreatedEvent : Event
    {
        public NewCardCreatedEvent(Guid cardId)
        {
            CardId = cardId;
            Name = (nameof(NewCardCreatedEvent));
        }

        public Guid CardId { get; set; }
    }
}