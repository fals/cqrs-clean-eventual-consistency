using System;

namespace Ametista.Core.Events
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
