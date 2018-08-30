using System;

namespace Ametista.Command.Commands
{
    public class CreateCardCommand : ICommand<CreateCardCommandResult>
    {
        public CreateCardCommand(string number, string cardHolder, DateTime expirationDate)
        {
            Number = number ?? throw new ArgumentNullException(nameof(number));
            CardHolder = cardHolder ?? throw new ArgumentNullException(nameof(cardHolder));
            ExpirationDate = expirationDate;
        }

        public string Number { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}