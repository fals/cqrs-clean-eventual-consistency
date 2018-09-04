using Ametista.Core.Events;
using Ametista.Core.Interfaces;
using Ametista.Core.Repository;
using Ametista.Query.Queries;
using Ametista.Query.QueryModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ametista.Query.EventHandlers
{
    public class SyncCardEventHandler : IEventHandler<CardCreatedEvent>
    {
        private readonly ReadDbContext readDbContext;

        public SyncCardEventHandler(ReadDbContext readDbContext)
        {
            this.readDbContext = readDbContext ?? throw new ArgumentNullException(nameof(readDbContext));
        }

        public async Task Handle(CardCreatedEvent e)
        {
            var cardView = new CardViewQueryModel()
            {
                CardHolder = e.Data.CardHolder,
                ExpirationDate = e.Data.ExpirationDate,
                Id = e.Data.Id,
                Number = e.Data.Number
            };

            await readDbContext.CardViewMaterializedView.InsertOneAsync(cardView);
        }
    }
}
