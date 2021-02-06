using System;

namespace Ametista.Api.Endpoints.GetCardList
{
    public class GetCardListRequest
    {
        public string CardHolder { get; set; }
        public string Number { get; set; }
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 1;
        public DateTime? ChargeDate { get; internal set; }
    }
}
