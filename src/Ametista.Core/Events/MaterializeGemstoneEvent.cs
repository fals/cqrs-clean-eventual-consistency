using System;

namespace Ametista.Core.Events
{
    public class MaterializeGemstoneEvent : Event
    {
        public Guid GemstoneId { get; set; }
        public MaterializeGemstoneEvent(Guid gemstoneId)
        {
            GemstoneId = gemstoneId;
            Name = nameof(MaterializeGemstoneEvent);
        }
    }
}
