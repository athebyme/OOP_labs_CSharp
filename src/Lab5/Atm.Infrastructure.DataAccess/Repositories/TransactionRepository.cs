using Atm.Transactions;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace Atm.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public TransactionRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider ?? throw new ArgumentNullException(nameof(connectionProvider));
    }

    public async Task<IEnumerable<Transaction>> FindTransactionsByUserIdAsync(int userId)
    {
        const string sql = """
                           select user_id, transaction_type, "billState", date
                           from atm_db.atm_transactions
                           where user_id = :userId;
                           """;
        NpgsqlConnection connection =
            await _connectionProvider.
                GetConnectionAsync(default)
                .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("userId", userId);
        using NpgsqlDataReader reader =
            await command.ExecuteReaderAsync().ConfigureAwait(false);
        var transactions = new List<Transaction>();
        while (await reader.ReadAsync().ConfigureAwait(false))
        {
            string transactionTypeStr = reader.GetString(1);
            if (Enum.TryParse(transactionTypeStr, out TransactionTypes transactionType))
            {
                transactions.Add(new Transaction(
                    reader.GetInt32(0),
                    transactionType,
                    reader.GetInt32(2),
                    reader.GetDateTime(3)));
            }
            else
            {
                throw new InvalidOperationException($"Invalid transaction type: {transactionTypeStr}");
            }
        }

        return transactions;
    }

    public Task AddTransaction(int userId, TransactionTypes type, int billState, DateTime dateTime)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Transaction>> FindUserByUsernameAsync(int userId)
    {
        throw new NotImplementedException();
    }
}