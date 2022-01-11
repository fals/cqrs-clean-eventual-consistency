using Ametista.Command.Abstractions;
using System;

namespace Ametista.Command.CreateTransaction
{
    public class CreateTransactionCommandResult : CommandResult
    {
        public Guid Id { get; set; }
        public Guid CardId { get; set; }
        public DateTimeOffset ChargeDate { get; set; }
        public string UniqueId { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }

        public CreateTransactionCommandResult(Guid id, Guid cardId, DateTimeOffset chargeDate, string uniqueId, decimal amount, string currencyCode, bool success)
        {
            Id = id;
            CardId = cardId;
            ChargeDate = chargeDate;
            UniqueId = uniqueId;
            Amount = amount;
            CurrencyCode = currencyCode;
            Success = success;
        }
    }
}