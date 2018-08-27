using Ametista.Command.Commands;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Threading.Tasks;
using Xunit;
using System.Net.Http;


namespace Ametista.IntegrationTest
{
    public class CardApiTests : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        private readonly WebApplicationFactory<Api.Startup> _factory;

        public CardApiTests(WebApplicationFactory<Api.Startup> factory)
        {
            _factory = factory;
        }

        //[Fact]
        //public async Task When_Creating_New_Card_Should_Return_Success()
        //{
        //    // Arrange
        //    var client = _factory.CreateClient();
        //    var request = new CreateCardRequest();
        //    request.CardHolder = "Teste";
        //    request.ExpirationDate = DateTime.Now;
        //    request.Number = "784789407238904742389";

        //    // Act
        //    var response = await client.PostAsJsonAsync("api/Cards/", request);

        //    //Assert
        //    response.EnsureSuccessStatusCode();
        //    Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        //}
    }
}
