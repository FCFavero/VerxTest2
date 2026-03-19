using Application.UseCases;
using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using Moq;

namespace Tests;

public class GetDailyBalanceUseCaseTests
{
    [Fact]
    public async Task Should_Return_Correct_Balance()
    {
        // Arrange
        var transactions = new List<Transaction>
        {
            new Transaction(100, TransactionType.Credit),
            new Transaction(50, TransactionType.Debit),
            new Transaction(200, TransactionType.Credit)
        };

        var repositoryMock = new Mock<ITransactionRepository>();

        repositoryMock
            .Setup(r => r.GetByDateAsync(It.IsAny<DateTime>()))
            .ReturnsAsync(transactions);

        var useCase = new GetDailyBalanceUseCase(repositoryMock.Object);

        // Act
        var result = await useCase.ExecuteAsync(DateTime.UtcNow);

        // Assert
        Assert.Equal(250, result.Balance);
    }
}