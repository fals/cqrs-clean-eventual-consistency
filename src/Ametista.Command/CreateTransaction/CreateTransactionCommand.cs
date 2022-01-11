using Ametista.Command.Abstractions;
using System;

namespace Ametista.Command.CreateTransaction
{
    public class CreateTransactionCommand : ICommand<CreateTransactionCommandResult>
    {
        public CreateTransactionCommand(decimal amount, string currencyCode, Guid cardId, string uniqueId, DateTimeOffset chargeDate)
        {
            Amount = amount;
            CurrencyCode = currencyCode ?? throw new ArgumentNullException(nameof(currencyCode));
            CardId = cardId;
            UniqueId = uniqueId ?? throw new ArgumentNullException(nameof(uniqueId));
            ChargeDate = chargeDate;
        }

        public decimal Amount { get; internal set; }
        public string CurrencyCode { get; internal set; }
        public Guid CardId { get; internal set; }
        public string UniqueId { get; internal set; }
        public DateTimeOffset ChargeDate { get; internal set; }
    }
}