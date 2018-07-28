using Ametista.Core;
using System;

namespace Ametista.Application.Commands
{
    public class CreateGemstoneCommand : ICommand<CreateGemstoneCommandResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ScientificName { get; set; }
        public decimal Price { get; set; }
    }
}
