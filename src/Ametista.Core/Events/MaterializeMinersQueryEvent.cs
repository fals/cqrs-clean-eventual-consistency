using System;

namespace Ametista.Core.Events
{
    public class MaterializeMinersQueryEvent : Event
    {
        public Guid MinerId { get; set; }

        public MaterializeMinersQueryEvent(Guid minerId)
        {
            MinerId = minerId;
            Name = nameof(MaterializeMinersQueryEvent);
        }
    }
}
