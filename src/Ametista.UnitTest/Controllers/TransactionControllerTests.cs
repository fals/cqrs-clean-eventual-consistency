using Ametista.Api.Controllers;
using Ametista.Api.Model;
using Ametista.Command;
using Ametista.Command.Commands;
using Ametista.Query;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Ametista.UnitTest.Controllers
{
    public class TransactionControllerTests
    {
        private readonly Mock<ICommandDispatcher> commandDispatcherMock;
        private readonly Mock<IQueryDispatcher> queryDispatcherMock;
        private readonly TransactionController controller;
        private readonly Guid id = Guid.NewGuid();
        private readonly Guid cardId = Guid.NewGuid();
        private readonly DateTimeOffset chargeDate = DateTimeOffset.Now;
        private readonly string uniqueId = Guid.NewGuid().ToString();

        public TransactionControllerTests()
        {
            commandDispatcherMock = new Mock<ICommandDispatcher>();
            commandDispatcherMock
                .Setup(x => x.Dispatch(It.IsAny<CreateTransactionCommand>()))
                .ReturnsAsync(new CreateTransactionCommandResult(id, cardId, chargeDate, uniqueId, 100M, "BRA", true));

            queryDispatcherMock = new Mock<IQueryDispatcher>();

            controller = new TransactionController(commandDispatcherMock.Object, queryDispatcherMock.Object);
        }

        [Fact]
        [Trait("Transaction", nameof(TransactionController))]
        public async Task Post_Retuns_Response_With_Amount()
        {
            // Arrange
            var request = GetResquest();

            // Act
            var data = await Post(request);

            // Assert
            Assert.Equal(data.Amount, request.Amount);
        }

        [Fact]
        [Trait("Transaction", nameof(TransactionController))]
        public async Task Post_Retuns_Response_With_CurrencyCode()
        {
            // Arrange
            var request = GetResquest();

            // Act
            var data = await Post(request);

            // Assert
            Assert.Equal(data.CurrencyCode, request.CurrencyCode);
        }

        [Fact]
        [Trait("Transaction", nameof(TransactionController))]
        public async Task Post_Retuns_Response_With_UniqueId()
        {
            // Arrange
            var request = GetResquest();

            // Act
            var data = await Post(request);

            // Assert
            Assert.Equal(data.UniqueId, request.UniqueId);
        }

        [Fact]
        [Trait("Transaction", nameof(TransactionController))]
        public async Task Post_Retuns_Response_With_CardId()
        {
            // Arrange
            var request = GetResquest();

            // Act
            var data = await Post(request);

            // Assert
            Assert.Equal(data.CardId, request.CardId);
        }

        [Fact]
        [Trait("Transaction", nameof(TransactionController))]
        public async Task Post_Retuns_Response_With_ChargeDate()
        {
            // Arrange
            var request = GetResquest();

            // Act
            var data = await Post(request);

            // Assert
            Assert.Equal(data.ChargeDate, request.ChargeDate);
        }

        [Fact]
        [Trait("Transaction", nameof(TransactionController))]
        public async Task Post_Retuns_Response_With_Id()
        {
            // Arrange
            var request = GetResquest();

            // Act
            var data = await Post(request);

            // Assert
            Assert.NotEqual(Guid.Empty, data.Id);
        }

        private async Task<CreateTransactionResponse> Post(CreateTransactionRequest request)
        {
            var response = await controller.Post(request);
            var result = Assert.IsType<OkObjectResult>(response);
            var data = Assert.IsType<CreateTransactionResponse>(result.Value);

            return data;
        }

        private CreateTransactionRequest GetResquest()
        {
            var request = new CreateTransactionRequest()
            {
                CardId = cardId,
                UniqueId = uniqueId,
                Amount = 100M,
                ChargeDate = chargeDate,
                CurrencyCode = "BRA"
            };

            return request;
        }
    }
}