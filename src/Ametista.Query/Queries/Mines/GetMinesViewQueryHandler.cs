using Ametista.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using Ametista.Core.Interfaces;
using Ametista.Core;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Ametista.Infrastructure.Queries
{
    public class GetMinesViewQueryHandler : IQueryHandler<GetMinesViewQuery, MinesViewQueryModel>
    {
        private readonly ReadDbContext _readDbContext;

        public GetMinesViewQueryHandler(ReadDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }

        public async Task<IEnumerable<MinesViewQueryModel>> HandleAsync(GetMinesViewQuery query)
        {
            var filter = Builders<MinesViewQueryModel>.Filter.Where(x => x.Name == query.Name);

            return await _readDbContext
                .MinesMaterializedView
                .Find(filter)
                .ToListAsync();
        }
    }
}
