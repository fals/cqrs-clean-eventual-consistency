using Ametista.Core;
using Ametista.Core.Interfaces;

namespace Ametista.UnitTest.Fakes
{
    internal class FakeEventBus : IEventBus
    {
        public void Publish(IEvent @event)
        {

        }

        public void Subscribe<T>() where T : IEvent
        {

        }
    }
}
