using System;
using System.ComponentModel.DataAnnotations;

namespace Ametista.Api.Model
{
    public class CreateTransactionRequest
    {
        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string CurrencyCode { get; set; }

        [Required]
        public Guid CardId { get; set; }

        [Required]
        public string UniqueId { get; set; }

        [Required]
        public DateTimeOffset ChargeDate { get; set; }
    }
}