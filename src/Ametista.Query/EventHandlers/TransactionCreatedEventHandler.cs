using Ametista.Core.Transactions;
using Ametista.Core.Interfaces;
using Ametista.Query.QueryModel;
using MongoDB.Driver;
using System.Threading.Tasks;
using Ametista.Query.Materializers;
using System;

namespace Ametista.Query.EventHandlers
{
    public class TransactionCreatedEventHandler : IEventHandler<Core.Transactions.TransactionCreatedEvent>
    {
        private readonly ReadDbContext readDbContext;
        private readonly ICache cache;
        private readonly ITransactionListQueryModelMaterializer transactionMaterializer;
        private readonly ICardListQueryModelMaterializer cardListMaterializer;

        public TransactionCreatedEventHandler(ReadDbContext readDbContext, ICache cache, 
            ITransactionListQueryModelMaterializer transactionMaterializer, 
            ICardListQueryModelMaterializer cardListMaterializer)
        {
            this.readDbContext = readDbContext ?? throw new ArgumentNullException(nameof(readDbContext));
            this.cache = cache ?? throw new ArgumentNullException(nameof(cache));
            this.transactionMaterializer = transactionMaterializer ?? throw new ArgumentNullException(nameof(transactionMaterializer));
            this.cardListMaterializer = cardListMaterializer ?? throw new ArgumentNullException(nameof(cardListMaterializer));
        }

        public async Task Handle(Core.Transactions.TransactionCreatedEvent e)
        {
            FilterDefinition<CardListQueryModel> filter = Builders<CardListQueryModel>.Filter.Eq("Id", e.Data.CardId);
            var cardList = await readDbContext.CardListMaterializedView
                .Find(filter)
                .FirstOrDefaultAsync();

            var transactionList = transactionMaterializer.Materialize(e.Data, cardList);
            cardList = cardListMaterializer.Materialize(e.Data, cardList);

            await cache.Delete(nameof(CardListQueryModel));
            await readDbContext.TransactionListMaterializedView.InsertOneAsync(transactionList);
            await readDbContext.CardListMaterializedView.ReplaceOneAsync(filter, cardList, new UpdateOptions { IsUpsert = true });
        }
    }
}