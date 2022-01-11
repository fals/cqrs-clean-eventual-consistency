using System.Threading.Tasks;

namespace Ametista.Query.Abstractions
{
    public interface IQueryHandler { }

    public interface IQueryHandler<TQuery, TQResult> : IQueryHandler
        where TQuery : IQuery<TQResult>
    {
        Task<TQResult> HandleAsync(TQuery query);
    }
}