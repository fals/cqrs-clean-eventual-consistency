using Ametista.Core.Interfaces;
using Ametista.Query.QueryModel;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ametista.Query.Queries
{
    public class GetCardListQueryHandler : IQueryHandler<GetCardListQuery, IEnumerable<CardListQueryModel>>
    {
        private readonly ReadDbContext readDbContext;
        private readonly ICache cache;

        public GetCardListQueryHandler(ReadDbContext readDbContext, ICache cache)
        {
            this.readDbContext = readDbContext ?? throw new ArgumentNullException(nameof(readDbContext));
            this.cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task<IEnumerable<CardListQueryModel>> HandleAsync(GetCardListQuery query)
        {
            try
            {
                var cached = await cache.Get<IEnumerable<CardListQueryModel>>(nameof(GetCardListQuery));

                if (cached != null && cached.Any())
                {
                    return cached;
                }

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

                await cache.Store<IEnumerable<CardListQueryModel>>(nameof(GetCardListQuery), itemsTask, null);

                return itemsTask;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
