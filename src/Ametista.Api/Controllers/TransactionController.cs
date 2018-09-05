using Ametista.Api.Model;
using Ametista.Command;
using Ametista.Command.Commands;
using Ametista.Query;
using Ametista.Query.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace Ametista.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ICommandDispatcher commandDispatcher;
        private readonly IQueryDispatcher queryDispatcher;

        public TransactionController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            this.commandDispatcher = commandDispatcher ?? throw new ArgumentNullException(nameof(commandDispatcher));
            this.queryDispatcher = queryDispatcher ?? throw new ArgumentNullException(nameof(queryDispatcher));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetTransactionsRequest request)
        {
            var query = new GetTransactionListQuery()
            {
                BetweenAmount = request.BetweenAmount,
                CardHolder = request.CardHolder,
                CardNumber = request.CardNumber,
                ChargeDate = request.ChargeDate,
                Limit = request.Limit,
                Offset = request.Offset
            };

            var result = await queryDispatcher.ExecuteAsync(query);

            if (!result.Any())
            {
                return NotFound(query);
            }

            var response = result.Select(x => new GetTransactionsResponse()
            {
                Amount = x.Amount,
                CardHolder = x.CardHolder,
                CardNumber = x.CardNumber,
                ChargeDate = x.ChargeDate,
                CurrencyCode = x.CurrencyCode,
                UniqueId = x.UniqueId
            });

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateTransactionRequest request)
        {
            var command = new CreateTransactionCommand(request.Amount, request.CurrencyCode, request.CardId, request.UniqueId, request.ChargeDate);
            var result = await commandDispatcher.Dispatch(command);

            if (result.Success)
            {
                var response = new CreateTransactionResponse()
                {
                    Amount = result.Amount,
                    CardId = result.CardId,
                    ChargeDate = result.ChargeDate,
                    CurrencyCode = result.CurrencyCode,
                    Id = result.Id,
                    UniqueId = result.UniqueId
                };

                return Ok(response);
            }

            return BadRequest(request);
        }
    }
}