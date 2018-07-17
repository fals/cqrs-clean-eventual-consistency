using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ametista.Core
{
    public interface IEventBus
    {
        Task<bool> Publish(IEvent @event);
        Task<bool> Subscribe(string eventName);
    }
}
