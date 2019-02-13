using Ametista.Core.Transactions;
using Ametista.Core.Interfaces;
using Ametista.Query.QueryModel;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Ametista.Query.EventHandlers
{
    public class MaterializeTransactionEventHandler : IEventHandler<TransactionCreatedEvent>
    {
        private readonly ReadDbContext readDbContext;
        private readonly ICache cache;

        public MaterializeTransactionEventHandler(ReadDbContext readDbContext, ICache cache)
        {
            this.readDbContext = readDbContext ?? throw new ArgumentNullException(nameof(readDbContext));
            this.cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task Handle(TransactionCreatedEvent e)
        {
            FilterDefinition<CardListQueryModel> filter = Builders<CardListQueryModel>.Filter.Eq("Id", e.Data.CardId);
            var cardList = await readDbContext.CardListMaterializedView
                .Find(filter)
                .FirstOrDefaultAsync();

            var transactionList = new TransactionListQueryModel()
            {
                Id = e.Data.Id,
                Amount = e.Data.Charge.Amount,
                ChargeDate = e.Data.ChargeDate,
                CardHolder = cardList.CardHolder,
                CardNumber = cardList.Number,
                CurrencyCode = e.Data.Charge.CurrencyCode,
                UniqueId = e.Data.UniqueId
            };

            if (!cardList.HighestTransactionAmount.HasValue || e.Data.Charge.Amount > cardList.HighestTransactionAmount)
            {
                cardList.HighestChargeDate = e.Data.ChargeDate;
                cardList.HighestTransactionId = e.Data.Id;
                cardList.HighestTransactionAmount = e.Data.Charge.Amount; 
            }

            cardList.TransactionCount += 1;

            await cache.Delete(nameof(CardListQueryModel));
            await readDbContext.TransactionListMaterializedView.InsertOneAsync(transactionList);
            await readDbContext.CardListMaterializedView.ReplaceOneAsync(filter, cardList, new UpdateOptions { IsUpsert = true });
        }
    }
}