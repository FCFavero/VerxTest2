using Domain.Entities;

namespace Domain.Repositories;

public interface ITransactionRepository
{
    Task AddAsync(Transaction transaction);

    Task<IEnumerable<Transaction>> GetByDateAsync(DateTime date);
}