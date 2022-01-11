using Ametista.Query.Abstractions;
using System;

namespace Ametista.Query.QueryModel
{
    public class CardViewQueryModel : IQueryModel
    {
        public string CardHolder { get; set; }

        public DateTime ExpirationDate { get; set; }

        public Guid Id { get; set; }

        public string Number { get; set; }
    }
}