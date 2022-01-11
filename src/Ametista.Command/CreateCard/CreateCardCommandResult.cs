using Ametista.Command.Abstractions;
using System;

namespace Ametista.Command.CreateCard
{
    public class CreateCardCommandResult : CommandResult
    {
        public CreateCardCommandResult()
        {
            Success = false;
        }

        public CreateCardCommandResult(Guid id, string number, string cardHolder, DateTime expirationDate, bool success)
        {
            Id = id;
            Number = number ?? throw new ArgumentNullException(nameof(number));
            CardHolder = cardHolder ?? throw new ArgumentNullException(nameof(cardHolder));
            ExpirationDate = expirationDate;
            Success = success;
        }

        public Guid Id { get; set; }
        public string Number { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}