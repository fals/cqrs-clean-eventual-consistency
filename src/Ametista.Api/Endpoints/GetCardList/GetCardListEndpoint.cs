using Ametista.Query;
using Ametista.Query.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ametista.Api.Endpoints.GetCardList
{
    [Route("api/cards")]
    [Produces("application/json")]
    public class GetCardListEndpoint : Controller
    {
        private readonly IQueryDispatcher queryDispatcher;

        public GetCardListEndpoint(IQueryDispatcher queryDispatcher)
        {
            this.queryDispatcher = queryDispatcher ?? throw new ArgumentNullException(nameof(queryDispatcher));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetCardListRequest request)
        {
            var query = new GetCardListQuery()
            {
                CardHolder = request.CardHolder,
                ChargeDate = request.ChargeDate,
                Number = request.Number,
                Limit = request.Limit,
                Offset = request.Offset
            };

            var result = await queryDispatcher.ExecuteAsync(query);

            if (!result.Any())
            {
                return NotFound(query);
            }

            var respose = result.Select(x => new GetCardListResponse()
            {
                Id = x.Id,
                Number = x.Number,
                CardHolder = x.CardHolder,
                ExpirationDate = x.ExpirationDate,
                HighestTransactionAmount= x.HighestTransactionAmount,
                HighestTransactionId = x.HighestTransactionId
            });

            return Ok(respose);
        }
    }
}