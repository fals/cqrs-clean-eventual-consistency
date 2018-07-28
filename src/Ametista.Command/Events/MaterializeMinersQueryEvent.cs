using Ametista.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Application.Events
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
