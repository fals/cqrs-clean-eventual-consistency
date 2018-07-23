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
    public class GetMinesQueryHandler : IQueryHandler<GetMinesQuery, MinesQueryModel>
    {
        private readonly ReadDbContext _readDbContext;

        public GetMinesQueryHandler(ReadDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }

        public async Task<IEnumerable<MinesQueryModel>> HandleAsync(GetMinesQuery query)
        {
            var filter = Builders<MinesQueryModel>.Filter.Where(x => x.Name == query.Name);

            return await _readDbContext
                .MinesMaterializedView
                .Find(filter)
                .ToListAsync();
        }
    }
}
