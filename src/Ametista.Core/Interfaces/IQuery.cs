namespace Ametista.Core
{
    public interface IQuery
    { }

    public interface IQuery<TModel> : IQuery where TModel : IQueryModel
    { }
}
