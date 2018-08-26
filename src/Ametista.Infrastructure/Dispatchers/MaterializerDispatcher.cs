using Ametista.Core;
using Ametista.Query;
using Autofac;
using System.Threading.Tasks;

namespace Ametista.Infrastructure
{
    public class MaterializerDispatcher : IMaterializerDispatcher
    {
        private readonly IComponentContext componentContext;

        public MaterializerDispatcher(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        public Task<bool> Dispatch<TEvent>(IMaterializer<TEvent> e) where TEvent : IEvent
        {
            if (e == null)
            {
                throw new System.ArgumentNullException(nameof(e));
            }

            var materializerTyoe = typeof(IMaterializer<>).MakeGenericType(e.GetType(), typeof(TEvent));

            dynamic handler = componentContext.Resolve(materializerTyoe);

            return (Task<bool>)materializerTyoe
                .GetMethod("Materialize")
                .Invoke(handler, new object[] { e });
        }
    }
}
