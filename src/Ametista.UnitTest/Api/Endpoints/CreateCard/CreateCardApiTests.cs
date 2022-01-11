using Ametista.Api.Endpoints.CreateCard;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Ametista.UnitTest.Api.Endpoints.CreateCard
{
    public class CreateCardApiTests : IClassFixture<ApiApplicationFactory>
    {
        private readonly ApiApplicationFactory _applicationFactory;

        public CreateCardApiTests(ApiApplicationFactory applicationFactory)
        {
            _applicationFactory = applicationFactory;
        }

        [Fact]
        public async Task Should_Return_Created_201()
        {
            // Arrange
            var client = _applicationFactory.CreateClient();

            var request = new CreateCardRequest
            {
                Number = "4694437484189508",
                CardHolder = "Filipe A. L. Souza",
                ExpirationDate = new DateTime(2022, 1, 12),
            };

            var requestContent = new StringContent(JsonSerializer.Serialize(request), System.Text.Encoding.UTF8, "application/json");

            // Act
            var result = await client.PostAsync("api/cards", requestContent);

            // Assert
            result.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
        }

        [Fact]
        public async Task Should_Return_BadRequest()
        {
            // Arrange
            var client = _applicationFactory.CreateClient();

            var request = new CreateCardRequest
            {
                Number = "123456",
                CardHolder = "Filipe A. L. Souza",
                ExpirationDate = new DateTime(2022, 1, 12),
            };

            var requestContent = new StringContent(JsonSerializer.Serialize(request), System.Text.Encoding.UTF8, "application/json");

            // Act
            var result = await client.PostAsync("api/cards", requestContent);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }
    }
}
