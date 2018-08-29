using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ametista.Core.Interfaces
{
    public interface IEventBus
    {
        void Publish(IEvent @event);
        void Subscribe<T>() where T : IEvent;
    }
}
