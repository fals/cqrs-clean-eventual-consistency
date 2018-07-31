using Ametista.Core;
using Ametista.Core.Entity;
using Ametista.Core.Repository;
using System;
using System.Threading.Tasks;
using Ametista.Core.Events;

namespace Ametista.Application.Commands
{
    public class CreateGemstoneCommandHandler : ICommandHandler<CreateGemstoneCommand, CreateGemstoneCommandResult>
    {
        private readonly IGemstoneRepository _writeOnlyRepository;
        private readonly IEventBus _eventBus;

        public CreateGemstoneCommandHandler(IGemstoneRepository writeOnlyRepository, IEventBus eventBus)
        {
            _writeOnlyRepository = writeOnlyRepository ?? throw new ArgumentNullException(nameof(writeOnlyRepository));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public async Task<CreateGemstoneCommandResult> Handle(CreateGemstoneCommand command)
        {
            command = command ?? throw new ArgumentNullException(nameof(command));

            Gemstone gemstone = Gemstone.CreateNew(command.Name, command.ScientificName, command.Price);
            MaterializeGemstoneEvent materializeGemstoneEvent = new MaterializeGemstoneEvent(gemstone.Id);

            await _writeOnlyRepository.Add(gemstone);
            await _eventBus.Publish(materializeGemstoneEvent);

            return new CreateGemstoneCommandResult()
            {
                Id = gemstone.Id,
                Name = gemstone.Name,
                Price = gemstone.Price,
                ScientificName = gemstone.ScientificName,
                Success = true
            };
        }
    }
}
