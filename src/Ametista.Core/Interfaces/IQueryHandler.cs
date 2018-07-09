using System.Threading.Tasks;

namespace Ametista.Core
{
    public interface IQueryHandler { } //this is just a convenience interface, used for ioc and testing

    public interface IQueryHandler<TQuery, TResult> : IQueryHandler
        where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
