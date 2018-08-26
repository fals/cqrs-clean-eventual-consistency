using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ametista.Command.Commands;
using Ametista.Core;
using Microsoft.AspNetCore.Mvc;

namespace Ametista.Api.Controllers
{
    [Route("api/[controller]")]
    public class CardController : Controller
    {
        private readonly ICommandDispatcher commandDispatcher;
        private readonly IQueryDispatcher queryDispatcher;

        public CardController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            this.commandDispatcher = commandDispatcher ?? throw new ArgumentNullException(nameof(commandDispatcher));
            this.queryDispatcher = queryDispatcher ?? throw new ArgumentNullException(nameof(queryDispatcher));
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateCardRequest request)
        {
            var command = new CreateCardCommand(request.Number, request.CardHolder, request.ExpirationDate);
            var result = await commandDispatcher.Dispatch(command);

            if (result.Success)
            {
                return Ok(result);
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
