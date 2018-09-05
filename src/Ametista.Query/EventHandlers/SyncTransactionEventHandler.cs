using Ametista.Core.Events;
using Ametista.Core.Interfaces;
using Ametista.Core.Repository;
using Ametista.Query.Queries;
using Ametista.Query.QueryModel;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Ametista.Query.EventHandlers
{
    public class SyncTransactionEventHandler : IEventHandler<TransactionCreatedEvent>
    {
        private readonly ReadDbContext readDbContext;

        public SyncTransactionEventHandler(ReadDbContext readDbContext)
        {
            this.readDbContext = readDbContext ?? throw new ArgumentNullException(nameof(readDbContext));
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

            if (e.Data.Charge.Amount > cardList.HighestTransactionAmount)
            {
                cardList.HighestChargeDate = e.Data.ChargeDate;
                cardList.HighestTransactionId = e.Data.Id;
                cardList.HighestTransactionAmount = e.Data.Charge.Amount; 
            }

            cardList.TransactionCount += 1;

            await readDbContext.TransactionListMaterializedView.InsertOneAsync(transactionList);
            await readDbContext.CardListMaterializedView.ReplaceOneAsync(x => x.Id == cardList.Id, cardList, new UpdateOptions { IsUpsert = true });
        }
    }
}