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

        public MaterializeCardEventHandler(ReadDbContext readDbContext)
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

            await readDbContext.CardViewMaterializedView.InsertOneAsync(cardView);
            await readDbContext.CardListMaterializedView.InsertOneAsync(cardList);
        }
    }
}
