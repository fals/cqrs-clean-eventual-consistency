using System;

namespace Ametista.Command.Commands
{
    public class CreateCardResponse
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
