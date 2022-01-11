using System.Threading.Tasks;

namespace Ametista.Query.Abstractions
{
    public interface IQueryDispatcher
    {
        Task<TModel> ExecuteAsync<TModel>(IQuery<TModel> query);
    }
}