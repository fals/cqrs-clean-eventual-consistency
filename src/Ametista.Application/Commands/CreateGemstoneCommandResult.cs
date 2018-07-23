using System;

namespace Ametista.Application.Commands
{
    public class CreateGemstoneCommandResult : CommandResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ScientificName { get; set; }
        public decimal Price { get; set; }
    }
}
