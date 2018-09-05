using Ametista.Api.Model;
using Ametista.Command;
using Ametista.Command.Commands;
using Ametista.Query;
using Ametista.Query.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ametista.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CardController : Controller
    {
        private readonly ICommandDispatcher commandDispatcher;
        private readonly IQueryDispatcher queryDispatcher;

        public CardController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            this.commandDispatcher = commandDispatcher ?? throw new ArgumentNullException(nameof(commandDispatcher));
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetCardByIdQuery(id);

            var queryResult = await queryDispatcher.ExecuteAsync(query);

            if (queryResult == null)
            {
                return BadRequest(id);
            }

            var resonse = new GetCardViewReponse()
            {
                CardHolder = queryResult.CardHolder,
                ExpirationDate = queryResult.ExpirationDate,
                Id = queryResult.Id,
                Number = queryResult.Number
            };

            return Ok(resonse);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateCardRequest request)
        {
            var command = new CreateCardCommand(request.Number, request.CardHolder, request.ExpirationDate);
            var result = await commandDispatcher.Dispatch(command);

            if (result.Success)
            {
                var response = new CreateCardResponse()
                {
                    Id = result.Id,
                    Number = result.Number,
                    CardHolder = result.CardHolder,
                    ExpirationDate = result.ExpirationDate
                };

                return Ok(response);
            }

            return BadRequest(request);
        }
    }
}