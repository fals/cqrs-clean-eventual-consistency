using System.Threading.Tasks;

namespace Ametista.Core
{
    public interface IQueryHandler { } //this is just a convenience interface, used for ioc and testing

    public interface IQueryHandler<TQuery, TModel> : IQueryHandler
        where TQuery : IQuery<TModel> where TModel : IQueryModel
    {
        Task<TModel> HandleAsync(TQuery query);
    }
}
