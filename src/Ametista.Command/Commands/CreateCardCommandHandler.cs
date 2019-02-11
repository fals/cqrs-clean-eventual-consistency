using Ametista.Core;
using Ametista.Core.Entities.Cards;
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
        private readonly ICardWriteOnlyRepository cardRepository;
        private readonly ValidationNotificationHandler notificationHandler;

        public CreateCardCommandHandler(IEventBus eventBus, ICardWriteOnlyRepository cardRepository)
        {
            this.eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            this.cardRepository = cardRepository ?? throw new ArgumentNullException(nameof(cardRepository));
            this.notificationHandler = new ValidationNotificationHandler();
        }

        public async Task<CreateCardCommandResult> Handle(CreateCardCommand command)
        {
            if (cardRepository.IsDuplicatedCardNumber(command.Number))
            {
                notificationHandler.AddNotification(nameof(CreateCardCommand.Number), $"Card number already exists {command.Number}");
            }

            var newCard = Card.CreateNewCard(command.Number, command.CardHolder, command.ExpirationDate);
            newCard.Validate(notificationHandler);

            if (newCard.Valid)
            {
                var success = await cardRepository.Add(newCard);

                if (success)
                {
                    var cardCreatedEvent = new CardCreatedEvent(newCard);

                    eventBus.Publish(cardCreatedEvent);
                }

                return new CreateCardCommandResult(newCard.Id, newCard.Number, newCard.CardHolder, newCard.ExpirationDate, success);
            }

            return CommandResult.CreateFailResult<CreateCardCommandResult>();
        }
    }
}