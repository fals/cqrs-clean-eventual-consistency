using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ametista.Query
{
    public interface IQueryHandler { }

    public interface IQueryHandler<TQuery, TModel> : IQueryHandler
        where TQuery : IQuery<TModel> where TModel : IQueryModel
    {
        Task<IEnumerable<TModel>> HandleAsync(TQuery query);
    }
}