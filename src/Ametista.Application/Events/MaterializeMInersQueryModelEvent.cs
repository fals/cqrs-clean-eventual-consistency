using Ametista.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Application.Events
{
    public class MaterializeMinersQueryModelEvent : Event
    {
        public MaterializeMInersQueryModelEvent()
        {
            Name = nameof(MaterializeMinersQueryModelEvent);
        }
    }
}
