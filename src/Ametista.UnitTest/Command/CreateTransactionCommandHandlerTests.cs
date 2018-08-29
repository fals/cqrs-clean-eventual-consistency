using Ametista.Command.Commands;
using Ametista.Core;
using Ametista.Core.Entity;
using Ametista.Core.Interfaces;
using Ametista.Core.Repository;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Ametista.UnitTest.Command
{
    public class CreateTransactionCommandHandlerTests
    {
        private readonly CreateTransactionCommandHandler handler;
        private readonly Mock<IEventBus> eventBusMock;
        private readonly Mock<ITransactionRepository> transactionRepositoryMock;

        public CreateTransactionCommandHandlerTests()
        {
            eventBusMock = new Mock<IEventBus>();
            transactionRepositoryMock = new Mock<ITransactionRepository>();
            transactionRepositoryMock.Setup(x => x.Add(It.IsAny<Transaction>()))
                .ReturnsAsync(true);

            handler = new CreateTransactionCommandHandler(eventBusMock.Object, transactionRepositoryMock.Object);
        }

        [Fact]
        [Trait("Transaction", nameof(CreateTransactionCommandHandler))]
        public async Task Return_Success_Result()
        {
            // Arrange
            var command = CreateTransactionCommand();

            // Act
            var result = await handler.Handle(command);

            // Assert
            Assert.True(result.Success);
        }

        [Fact]
        [Trait("Transaction", nameof(CreateTransactionCommandHandler))]
        public async Task Return_Id_Within_Result()
        {
            // Arrange
            var command = CreateTransactionCommand();

            // Act
            var result = await handler.Handle(command);

            // Assert
            Assert.NotEqual(Guid.Empty, result.Id);
        }

        [Fact]
        [Trait("Transaction", nameof(CreateTransactionCommandHandler))]
        public async Task Return_UniqueId_Within_Result()
        {
            // Arrange
            var command = CreateTransactionCommand();

            // Act
            var result = await handler.Handle(command);

            // Assert
            Assert.Equal(command.UniqueId, result.UniqueId);
        }

        [Fact]
        [Trait("Transaction", nameof(CreateTransactionCommandHandler))]
        public async Task Return_ChargeDate_Within_Result()
        {
            // Arrange
            var command = CreateTransactionCommand();

            // Act
            var result = await handler.Handle(command);

            // Assert
            Assert.Equal(command.ChargeDate, result.ChargeDate);
        }

        [Fact]
        [Trait("Transaction", nameof(CreateTransactionCommandHandler))]
        public async Task Return_Amount_Within_Result()
        {
            // Arrange
            var command = CreateTransactionCommand();

            // Act
            var result = await handler.Handle(command);

            // Assert
            Assert.Equal(command.Amount, result.Amount);
        }

        [Fact]
        [Trait("Transaction", nameof(CreateTransactionCommandHandler))]
        public async Task Return_CurrencyCode_Within_Result()
        {
            // Arrange
            var command = CreateTransactionCommand();

            // Act
            var result = await handler.Handle(command);

            // Assert
            Assert.Equal(command.CurrencyCode, result.CurrencyCode);
        }

        public CreateTransactionCommand CreateTransactionCommand()
        {
            return new CreateTransactionCommand(100M, "BRA", Guid.NewGuid(), Guid.NewGuid().ToString(), DateTimeOffset.Now);
        }
    }
}