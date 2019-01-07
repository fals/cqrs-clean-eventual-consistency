using Ametista.Core.Events;
using Ametista.Core.Interfaces;
using Ametista.Query.QueryModel;
using System;
using System.Threading.Tasks;

namespace Ametista.Query.EventHandlers
{
    public class MaterializeCardEventHandler : IEventHandler<CardCreatedEvent>
    {
        private readonly ReadDbContext readDbContext;
        private readonly ICache cache;

        public MaterializeCardEventHandler(ReadDbContext readDbContext, ICache cache)
        {
            this.readDbContext = readDbContext ?? throw new ArgumentNullException(nameof(readDbContext));
            this.cache = cache ?? throw new ArgumentNullException(nameof(cache));
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

            var cardList = new CardListQueryModel()
            {
                Id = e.Data.Id,
                Number = e.Data.Number,
                CardHolder = e.Data.CardHolder,
                ExpirationDate = e.Data.ExpirationDate,
                HighestChargeDate = null,
                HighestTransactionAmount = null,
                HighestTransactionId = null,
                TransactionCount = 0
            };

            await cache.Delete(nameof(CardListQueryModel));
            await cache.Delete(nameof(CardViewQueryModel));
            await readDbContext.CardViewMaterializedView.InsertOneAsync(cardView);
            await readDbContext.CardListMaterializedView.InsertOneAsync(cardList);
        }
    }
}
