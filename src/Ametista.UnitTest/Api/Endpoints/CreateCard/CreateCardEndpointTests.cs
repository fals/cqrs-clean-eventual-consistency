using Ametista.Api.Endpoints.CreateCard;
using Ametista.Command.Abstractions;
using Ametista.Command.CreateCard;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Ametista.UnitTest.Api.Endpoints.CreateCard
{
    public class CreateCardEndpointTests
    {
        private readonly CreateCardEndpoint sut;
        private readonly Mock<ICommandDispatcher> commandDispatcherMock;

        public CreateCardEndpointTests()
        {
            commandDispatcherMock = new Mock<ICommandDispatcher>();
            sut = new CreateCardEndpoint(commandDispatcherMock.Object);
        }

        [Fact]
        public async Task Should_Return_CreatedResult_With_Correct_Data()
        {
            // Arrange
            var request = new CreateCardRequest
            {
                Number = "xxxx-xxxx-xxxx-xxx",
                CardHolder = "Filipe A. L. Souza",
                ExpirationDate = new DateTime(2022, 1, 12),
            };

            var commandResult = new CreateCardCommandResult(
                id: Guid.NewGuid(),
                number: "xxxx-xxxx-xxxx-xxx",
                cardHolder: "Filipe A. L. Souza",
                expirationDate: new DateTime(2022, 1, 12),
                success: true
                );

            commandDispatcherMock
                .Setup(x => x.Dispatch(It.IsAny<CreateCardCommand>()))
                .ReturnsAsync(commandResult);

            // Act
            var actionResult = await sut.Post(request);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(actionResult);
            var response = Assert.IsAssignableFrom<CreateCardResponse>(createdResult.Value);
            AssertResponse(commandResult, response);
        }

        private void AssertResponse(CreateCardCommandResult commandResult, CreateCardResponse response)
        {
            Assert.Equal(commandResult.Id, response.Id);
            Assert.Equal(commandResult.Number, response.Number);
            Assert.Equal(commandResult.CardHolder, response.CardHolder);
            Assert.Equal(commandResult.ExpirationDate, response.ExpirationDate);
        }
    }
}
