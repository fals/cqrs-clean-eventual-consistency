using Ametista.Core;
using Ametista.Core.Interfaces;
using Ametista.Query;
using Autofac;
using System.Threading.Tasks;

namespace Ametista.Infrastructure
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IComponentContext componentContext;

        public EventDispatcher(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        public Task<bool> Dispatch<TEvent>(TEvent e) where TEvent : IEvent
        {
            if (e == null)
            {
                throw new System.ArgumentNullException(nameof(e));
            }

            var eventType = typeof(IEventHandler<>).MakeGenericType(e.GetType(), typeof(TEvent));

            dynamic handler = componentContext.Resolve(eventType);

            return (Task<bool>)eventType
                .GetMethod("Handle")
                .Invoke(handler, new object[] { e });
        }
    }
}
