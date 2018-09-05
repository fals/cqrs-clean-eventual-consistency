using MongoDB.Driver.Linq;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Ametista.Query
{
    public static class LinqExtensions
    {
        public static IMongoQueryable<TSource> WhereIf<TSource>(this IMongoQueryable<TSource> source, bool condition, Expression<Func<TSource, bool>> predicate)
        {
            if (condition)
                return (IMongoQueryable<TSource>)Queryable.Where(source, predicate);
            else
                return source;
        }
    }
}
