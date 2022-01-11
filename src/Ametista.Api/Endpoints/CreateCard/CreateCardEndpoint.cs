using Ametista.Command.Abstractions;
using Ametista.Command.CreateCard;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Ametista.Api.Endpoints.CreateCard
{
    [Route("api/cards")]
    [Produces("application/json")]
    public class CreateCardEndpoint : Controller
    {
        private readonly ICommandDispatcher commandDispatcher;

        public CreateCardEndpoint(ICommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher ?? throw new ArgumentNullException(nameof(commandDispatcher));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCardRequest request)
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