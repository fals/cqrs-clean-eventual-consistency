using Ametista.Core;
using Ametista.Query;
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

        public Task<TModel> ExecuteAsync<TModel>(IQuery<TModel> query) where TModel : IQueryModel
        {
            var queryHandlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TModel));

            var handler = componentContext.Resolve(queryHandlerType);

            return (Task<TModel>)queryHandlerType
                .GetMethod("HandleAsync")
                .Invoke(handler, new object[] { query });
        }
    }
}
