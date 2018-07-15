using System.Threading.Tasks;

namespace Ametista.Core
{
    public interface IQueryHandler { }

    public interface IQueryHandler<TQuery, TModel> : IQueryHandler
        where TQuery : IQuery<TModel> where TModel : IQueryModel
    {
        Task<TModel> HandleAsync(TQuery query);
    }
}
