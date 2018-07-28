using Ametista.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Application.Events
{
    public class MaterializeMinesQueryModelEvent : Event
    {
        public Guid MineId { get; set; }
        public MaterializeMinesQueryModelEvent(Guid mineId)
        {
            MineId = mineId;
            Name = nameof(MaterializeMinesQueryModelEvent);
        }
    }
}
