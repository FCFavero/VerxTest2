using Domain.Entities;
using Domain.Repositories;

namespace Infra.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly List<Transaction> _transactions = new();

    public Task AddAsync(Transaction transaction)
    {
        _transactions.Add(transaction);

        return Task.CompletedTask;
    }

    public Task<IEnumerable<Transaction>> GetByDateAsync(DateTime date)
    {
        var result = _transactions
            .Where(t => t.Date.Date == date.Date);

        return Task.FromResult(result.AsEnumerable());
    }
}
