using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ametista.Query.QueryModel;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Ametista.Query.Queries
{
    public class GetTransactionListQueryHandler : IQueryHandler<GetTransactionListQuery, IEnumerable<TransactionListQueryModel>>
    {
        private readonly ReadDbContext readDbContext;
        
        public GetTransactionListQueryHandler(ReadDbContext readDbContext)
        {
            this.readDbContext = readDbContext ?? throw new ArgumentNullException(nameof(readDbContext));
        }

        public async Task<IEnumerable<TransactionListQueryModel>> HandleAsync(GetTransactionListQuery query)
        {
            var result = readDbContext
                .TransactionListMaterializedView
                .AsQueryable()
                .Where(x => x.CardNumber == query.CardNumber);

            var itemsTask = await result
                .Skip(query.Offset)
                .Take(query.Limit)
                .ToListAsync();
            
            return itemsTask;
        }
    }
}
