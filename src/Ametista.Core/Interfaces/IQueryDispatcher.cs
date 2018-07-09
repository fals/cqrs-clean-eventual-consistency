using System.Threading.Tasks;

namespace Ametista.Core
{
    public interface IQueryDispatcher
    {
        Task<TModel> ExecuteAsync<TModel>(IQuery<TModel> query) where TModel : IQueryModel;
    }
}
