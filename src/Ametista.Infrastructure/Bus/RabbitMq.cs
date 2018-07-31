using Ametista.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ametista.Infrastructure.Bus
{
    public class RabbitMq : IEventBus
    {
        public RabbitMq()
        {

        }

        public Task<bool> Publish(IEvent @event)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Subscribe(string eventName)
        {
            throw new NotImplementedException();
        }
    }
}
