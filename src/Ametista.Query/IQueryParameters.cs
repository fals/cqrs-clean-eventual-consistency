namespace Ametista.Query
{
    public interface IQueryParameters<TQuery>  where TQuery : IQuery
    {
        T GetParameters<T>(TQuery model);
    }
}
