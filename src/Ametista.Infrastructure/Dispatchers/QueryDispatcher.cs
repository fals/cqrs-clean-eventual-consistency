using Ametista.Core;
using Autofac;
using System.Reflection;
using System.Threading.Tasks;

namespace Ametista.Infrastructure
{   
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IComponentContext componentContext;

        public QueryDispatcher(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        public Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query)
        {
            var queryHandlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            var handler = componentContext.Resolve(queryHandlerType);

            return (Task<TResult>)queryHandlerType
                .GetMethod("HandleAsync")
                .Invoke(handler, new object[] { query });
        }
    }
}
