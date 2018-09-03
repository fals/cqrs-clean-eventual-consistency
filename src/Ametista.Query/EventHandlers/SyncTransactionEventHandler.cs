using Ametista.Core.Events;
using Ametista.Core.Interfaces;
using Ametista.Core.Repository;
using Ametista.Query.Queries;
using Ametista.Query.QueryModel;
using System;
using System.Threading.Tasks;

namespace Ametista.Query.EventHandlers
{
    public class SyncTransactionEventHandler : IEventHandler<TransactionCreatedEvent>
    {
        private readonly ReadDbContext readDbContext;
        private readonly ICardRepository cardRepository;

        public SyncTransactionEventHandler(ReadDbContext readDbContext, ICardRepository cardRepository)
        {
            this.readDbContext = readDbContext ?? throw new ArgumentNullException(nameof(readDbContext));
            this.cardRepository = cardRepository ?? throw new ArgumentNullException(nameof(cardRepository));
        }

        public async Task Handle(TransactionCreatedEvent e)
        {
            var card = await cardRepository.FindAsync(e.Data.CardId);

            var transactionList = new TransactionListQueryModel()
            {
                Id = e.Data.Id,
                Amount = e.Data.Charge.Amount,
                ChargeDate = e.Data.ChargeDate,
                CardHolder = card.CardHolder,
                CardNumber = card.Number,
                CurrencyCode = e.Data.Charge.CurrencyCode,
                UniqueId = e.Data.UniqueId
            };

            await readDbContext.TransactionListMaterializedView.InsertOneAsync(transactionList);
        }
    }
}