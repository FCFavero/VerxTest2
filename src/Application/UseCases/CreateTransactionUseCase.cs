using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;

namespace Application.UseCases;

public class CreateTransactionUseCase
{
    private readonly ITransactionRepository _repository;

    public CreateTransactionUseCase(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(decimal amount, TransactionType type)
    {
        var transaction = new Transaction(amount, type);

        await _repository.AddAsync(transaction);
    }
}

public class GetDailyBalanceUseCase
{
    private readonly ITransactionRepository _repository;

    public GetDailyBalanceUseCase(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<DailyBalance> ExecuteAsync(DateTime date)
    {
        var transactions = await _repository.GetByDateAsync(date);

        var balance = new DailyBalance(date);

        foreach (var transaction in transactions)
        {
            if (transaction.IsCredit())
                balance.AddCredit(transaction.Amount);
            else
                balance.AddDebit(transaction.Amount);
        }

        return balance;
    }
}