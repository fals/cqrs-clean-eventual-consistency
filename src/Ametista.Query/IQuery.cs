namespace Ametista.Query
{
    public interface IQuery
    { }

    public interface IQuery<TModel> : IQuery where TModel : IQueryModel
    { }
}