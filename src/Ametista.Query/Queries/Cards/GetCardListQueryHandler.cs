using Ametista.Query.QueryModel;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ametista.Query.Queries
{
    public class GetCardListQueryHandler : IQueryHandler<GetCardListQuery, IEnumerable<CardListQueryModel>>
    {
        private readonly ReadDbContext readDbContext;

        public GetCardListQueryHandler(ReadDbContext readDbContext)
        {
            this.readDbContext = readDbContext ?? throw new ArgumentNullException(nameof(readDbContext));
        }

        public async Task<IEnumerable<CardListQueryModel>> HandleAsync(GetCardListQuery query)
        {
            try
            {
                var result = readDbContext
               .CardListMaterializedView
               .AsQueryable()
               .WhereIf(!string.IsNullOrEmpty(query.Number), x => x.Number.Contains(query.Number))
               .WhereIf(!string.IsNullOrEmpty(query.CardHolder), x => x.CardHolder.Contains(query.CardHolder))
               .WhereIf(query.ChargeDate.HasValue, x => x.ExpirationDate == query.ChargeDate);

                var itemsTask = await result
                    .Skip(query.Offset)
                    .Take(query.Limit)
                    .ToListAsync();

                return itemsTask;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
