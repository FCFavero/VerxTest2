using Application.UseCases;
using Domain.Enums;
using Domain.Repositories;
using Moq;

namespace Tests
{
    public class CreateTransactionUseCaseTests
    {
        [Fact]
        public async Task Should_Create_Transaction()
        {
            // Arrange
            var repositoryMock = new Mock<ITransactionRepository>();

            var useCase = new CreateTransactionUseCase(repositoryMock.Object);

            // Act
            await useCase.ExecuteAsync(100, TransactionType.Credit);

            // Assert
            repositoryMock.Verify(
                r => r.AddAsync(It.IsAny<Domain.Entities.Transaction>()),
                Times.Once
            );
        }
    }
}
