using Ametista.Application.Commands;
using Ametista.Core;
using Ametista.Core.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ametista.UnitTest.Application
{
    public class CreateGemstomeCommandTest
    {
        private readonly Mock<IGemstoneWriteOnlyRepository> repository;
        private readonly Mock<IEventBus> eventBus;
        private readonly ICommandHandler<CreateGemstoneCommand, CreateGemstoneCommandResult> handler;

        public CreateGemstomeCommandTest()
        {
            repository = new Mock<IGemstoneWriteOnlyRepository>();
            eventBus = new Mock<IEventBus>();
            handler = new CreateGemstoneCommandHandler(repository.Object, eventBus.Object);
        }

        [Fact]
        [Trait("Gemstone", nameof(CreateGemstoneCommandHandler))]
        public async Task When_Creating_Gemstone_Fill_Name()
        {
            // Arrange
            CreateGemstoneCommand command = CreateCommand();

            // Act
            var result = await handler.Handle(command);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(command.Name, result.Name);
        }

        [Fact]
        [Trait("Gemstone", nameof(CreateGemstoneCommandHandler))]
        public async Task When_Creating_Gemstone_Fill_ScientificName()
        {
            // Arrange
            CreateGemstoneCommand command = CreateCommand();

            // Act
            var result = await handler.Handle(command);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(command.ScientificName, result.ScientificName);
        }

        [Fact]
        [Trait("Gemstone", nameof(CreateGemstoneCommandHandler))]
        public async Task When_Creating_Gemstone_Fill_Price()
        {
            // Arrange
            CreateGemstoneCommand command = CreateCommand();

            // Act
            var result = await handler.Handle(command);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(command.Price, result.Price);
        }

        [Fact]
        [Trait("Gemstone", nameof(CreateGemstoneCommandHandler))]
        public async Task When_Creating_Gemstone_Thorw_ArgumentException_With_Null_Command()
        {
            // Arrange
            CreateGemstoneCommand command = null;

            // Assert, Act
            await Assert.ThrowsAsync<ArgumentNullException>(() => handler.Handle(command));
        }


        private CreateGemstoneCommand CreateCommand()
        {
            return new CreateGemstoneCommand() { Name = "Ametista", ScientificName = "Ametistae", Price = 1000 };
        }
    }
}
