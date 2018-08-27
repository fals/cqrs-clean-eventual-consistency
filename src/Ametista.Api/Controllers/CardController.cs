using Ametista.Api.Models;
using Ametista.Command;
using Ametista.Command.Commands;
using Ametista.Query;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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

            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}