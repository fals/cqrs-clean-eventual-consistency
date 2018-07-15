using Ametista.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Application.Events
{
    public class MaterializeMinesQueryModelEvent : Event
    {
        public MaterializeMinesQueryModelEvent()
        {
            Name = nameof(MaterializeMinesQueryModelEvent);
        }
    }
}
