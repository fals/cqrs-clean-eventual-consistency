namespace Ametista.Query.Abstractions
{
    public interface IMaterializer<TQueryModel, TSource> where TQueryModel : IQueryModel
    {
        TQueryModel Materialize(TSource source);
    }

    public interface IMaterializer<TQueryModel, TSource1, TSource2> where TQueryModel : IQueryModel
    {
        TQueryModel Materialize(TSource1 source1, TSource2 source2);
    }
}
