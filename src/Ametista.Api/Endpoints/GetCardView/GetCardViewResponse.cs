using System;

namespace Ametista.Api.Endpoints.GetCardView
{
    public class GetCardViewResponse
    {
        public string CardHolder { get; set; }

        public DateTime ExpirationDate { get; set; }

        public Guid Id { get; set; }

        public string Number { get; set; }
    }
}