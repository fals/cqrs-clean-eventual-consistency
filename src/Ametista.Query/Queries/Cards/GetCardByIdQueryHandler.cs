using Ametista.Query.QueryModel;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Ametista.Query.Queries
{
    public class GetCardByIdQueryHandler : IQueryHandler<GetCardByIdQuery, CardViewQueryModel>
    {
        private readonly ReadDbContext readDbContext;

        public GetCardByIdQueryHandler(ReadDbContext readDbContext)
        {
            this.readDbContext = readDbContext ?? throw new ArgumentNullException(nameof(readDbContext));
        }

        public async Task<CardViewQueryModel> HandleAsync(GetCardByIdQuery query)
        {
            try
            {
                FilterDefinition<CardViewQueryModel> filter = Builders<CardViewQueryModel>.Filter.Eq("Id", query.Id);
                var result = await readDbContext.CardViewMaterializedView.FindAsync(filter);

                return await result.FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}