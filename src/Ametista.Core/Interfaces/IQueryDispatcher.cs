using System.Threading.Tasks;

namespace Ametista.Core
{
    public interface IQueryDispatcher
    {
        Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query);
    }
}
