using Ametista.Api.Controllers;
using Ametista.Api.Model;
using Ametista.Command;
using Ametista.Command.Commands;
using Ametista.Query;
using Ametista.Query.Queries;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Ametista.UnitTest.Controllers
{
    public class CardControllerTests
    {
        private readonly Mock<ICommandDispatcher> commandDispatcherMock;
        private readonly Mock<IQueryDispatcher> queryDispatcherMock;
        private readonly CardController controller;

        public CardControllerTests()
        {
            commandDispatcherMock = new Mock<ICommandDispatcher>();
            commandDispatcherMock
                .Setup(x => x.Dispatch(It.IsAny<CreateCardCommand>()))
                .ReturnsAsync(new CreateCardCommandResult(Guid.NewGuid(), "784789407238904742389", "Teste", DateTime.Now.Date, true));

            queryDispatcherMock = new Mock<IQueryDispatcher>();
            queryDispatcherMock
               .Setup(x => x.ExecuteAsync(It.IsAny<GetCardByIdQuery>()))
               .ReturnsAsync(GetCardViewQueryModel());

            controller = new CardController(commandDispatcherMock.Object, queryDispatcherMock.Object);
        }

        [Fact]
        [Trait("Card", nameof(CardController))]
        public async Task Post_Retuns_Response_With_Number()
        {
            // Arrange
            var request = GetCreateCardResquest();

            // Act
            var data = await Post(request);

            // Assert
            Assert.Equal(data.Number, request.Number);
        }

        [Fact]
        [Trait("Card", nameof(CardController))]
        public async Task Post_Retuns_Response_With_CardHolder()
        {
            // Arrange
            var request = GetCreateCardResquest();

            // Act
            var data = await Post(request);

            // Assert
            Assert.Equal(data.CardHolder, request.CardHolder);
        }

        [Fact]
        [Trait("Card", nameof(CardController))]
        public async Task Post_Retuns_Response_With_ExpirationDate()
        {
            // Arrange
            var request = GetCreateCardResquest();

            // Act
            var data = await Post(request);

            // Assert
            Assert.Equal(data.ExpirationDate, request.ExpirationDate);
        }

        [Fact]
        [Trait("Card", nameof(CardController))]
        public async Task Post_Retuns_Response_With_Id()
        {
            // Arrange
            var request = GetCreateCardResquest();

            // Act
            var data = await Post(request);

            // Assert
            Assert.NotEqual(Guid.Empty, data.Id);
        }

        [Fact]
        [Trait("Card", nameof(CardController))]
        public async Task GetById_Retuns_Response()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var data = await GetCardById(id);

            // Assert
            Assert.NotNull(data);
        }

        private async Task<CreateCardResponse> Post(CreateCardRequest request)
        {
            var response = await controller.Post(request);
            var result = Assert.IsType<OkObjectResult>(response);
            var data = Assert.IsType<CreateCardResponse>(result.Value);

            return data;
        }

        private async Task<CardViewReponse> GetCardById(Guid id)
        {
            var response = await controller.GetById(id);
            var result = Assert.IsType<OkObjectResult>(response);
            var data = Assert.IsType<CardViewReponse>(result.Value);

            return data;
        }

        private CardViewQueryModel GetCardViewQueryModel()
        {
            return new CardViewQueryModel()
            {
                CardHolder = "Teste",
                ExpirationDate = DateTime.Now,
                Id = Guid.NewGuid(),
                Number = Guid.NewGuid().ToString()
            };
        }

        private CreateCardRequest GetCreateCardResquest()
        {
            var request = new CreateCardRequest();
            request.CardHolder = "Teste";
            request.ExpirationDate = DateTime.Now.Date;
            request.Number = "784789407238904742389";

            return request;
        }
    }
}