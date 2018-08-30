using Ametista.Core.Entity;
using Ametista.Core.Events;
using Ametista.Core.Interfaces;
using Ametista.Core.Repository;
using Ametista.Core.ValueObjects;
using System;
using System.Threading.Tasks;

namespace Ametista.Command.Commands
{
    public class CreateTransactionCommandHandler : ICommandHandler<CreateTransactionCommand, CreateTransactionCommandResult>
    {
        private readonly IEventBus eventBus;
        private readonly ITransactionRepository transactionRepository;

        public CreateTransactionCommandHandler(IEventBus eventBus, ITransactionRepository transactionRepository)
        {
            this.eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            this.transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
        }

        public async Task<CreateTransactionCommandResult> Handle(CreateTransactionCommand command)
        {
            var charge = new Money(command.Amount, command.CurrencyCode);
            var newTransaction = Transaction.CreateTransactionForCard(command.CardId, command.UniqueId, command.ChargeDate, charge);

            var success = await transactionRepository.Add(newTransaction);

            if (success)
            {
                var transactionCreatedEvent = new NewTransactionCreatedEvent(newTransaction.Id);

                eventBus.Publish(transactionCreatedEvent);
            }

            return new CreateTransactionCommandResult(
                newTransaction.Id,
                newTransaction.CardId,
                newTransaction.ChargeDate,
                newTransaction.UniqueId,
                newTransaction.Charge.Amount,
                newTransaction.Charge.CurrencyCode,
                success);
        }
    }
}