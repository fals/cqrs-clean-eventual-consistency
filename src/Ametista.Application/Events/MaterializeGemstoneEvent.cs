using Ametista.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Application.Events
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
