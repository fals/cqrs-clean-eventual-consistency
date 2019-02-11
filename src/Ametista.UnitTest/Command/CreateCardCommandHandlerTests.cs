using Ametista.Command.Commands;
using Ametista.Core.Entities.Cards;
using Ametista.Core.Interfaces;
using Ametista.Core.Repository;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Ametista.UnitTest.Command
{
    public class CreateCardCommandHandlerTests
    {
        private readonly CreateCardCommandHandler handler;
        private readonly Mock<IEventBus> eventBusMock;
        private readonly Mock<ICardWriteOnlyRepository> cardRepositoryMock;

        public CreateCardCommandHandlerTests()
        {
            eventBusMock = new Mock<IEventBus>();
            cardRepositoryMock = new Mock<ICardWriteOnlyRepository>();
            cardRepositoryMock.Setup(x => x.Add(It.IsAny<Card>()))
                .ReturnsAsync(true);

            handler = new CreateCardCommandHandler(eventBusMock.Object, cardRepositoryMock.Object);
        }

        [Fact]
        [Trait("Card", nameof(CreateCardCommandHandler))]
        public async Task Return_Success_Result()
        {
            // Arrange
            var command = CreateCardCommand();

            // Act
            var result = await handler.Handle(command);

            // Assert
            Assert.True(result.Success);
        }

        [Fact]
        [Trait("Card", nameof(CreateCardCommandHandler))]
        public async Task Return_CardHolder_Within_Result()
        {
            // Arrange
            var command = CreateCardCommand();

            // Act
            var result = await handler.Handle(command);

            // Assert
            Assert.Equal(command.CardHolder, result.CardHolder);
        }

        [Fact]
        [Trait("Card", nameof(CreateCardCommandHandler))]
        public async Task Return_Number_Within_Result()
        {
            // Arrange
            var command = CreateCardCommand();

            // Act
            var result = await handler.Handle(command);

            // Assert
            Assert.Equal(command.Number, result.Number);
        }

        [Fact]
        [Trait("Card", nameof(CreateCardCommandHandler))]
        public async Task Return_ExpirationDate_Within_Result()
        {
            // Arrange
            var command = CreateCardCommand();

            // Act
            var result = await handler.Handle(command);

            // Assert
            Assert.Equal(command.ExpirationDate, result.ExpirationDate);
        }

        private CreateCardCommand CreateCardCommand()
        {
            return new CreateCardCommand("33334444555566667777", "MR FILIPE LIMA", DateTime.Now.Date);
        }
    }
}