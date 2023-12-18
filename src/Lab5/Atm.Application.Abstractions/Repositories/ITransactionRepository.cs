using Atm.Transactions;

namespace Atm.Repositories;

public interface ITransactionRepository
{
    Task<IEnumerable<Transaction>> FindTransactionsByUserIdAsync(int userId);
    Task AddTransaction(int userId, TransactionTypes type, int billState, DateTime dateTime);
}