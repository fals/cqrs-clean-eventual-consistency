using Ametista.Core;
using Ametista.Core.Entity;
using Ametista.Core.Events;
using Ametista.Core.Interfaces;
using Ametista.Core.Repository;
using System;
using System.Threading.Tasks;

namespace Ametista.Command.Commands
{
    public class CreateCardCommandHandler : ICommandHandler<CreateCardCommand, CreateCardCommandResult>
    {
        private readonly IEventBus eventBus;
        private readonly ICardRepository cardRepository;

        public CreateCardCommandHandler(IEventBus eventBus, ICardRepository cardRepository)
        {
            this.eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            this.cardRepository = cardRepository ?? throw new ArgumentNullException(nameof(cardRepository));
        }

        public async Task<CreateCardCommandResult> Handle(CreateCardCommand command)
        {
            var newCard = Card.CreateNewCard(command.Number, command.CardHolder, command.ExpirationDate);

            var success = await cardRepository.Add(newCard);

            if (success)
            {
                var cardCreatedEvent = new NewCardCreatedEvent(newCard.Id);

                    eventBus.Publish(cardCreatedEvent);
            }

            return new CreateCardCommandResult(newCard.Id, newCard.Number, newCard.CardHolder, newCard.ExpirationDate, success);
        }
    }
}