using Atm.Bills;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace Atm.Repositories;

public class BillRepository : IBillRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public BillRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider ?? throw new ArgumentNullException(nameof(connectionProvider));
    }

    public async Task<Bill?> FindUserBillById(int userId)
    {
        const string sql = """
                           select user_id, money_bill
                           from atm_db.atm_users_bill
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

        return await
            reader.ReadAsync().ConfigureAwait(false) is false ?
            null :
            new Bill(userId, reader.GetInt32(1));
    }

    public async Task ChangeBillState(int userId, int amount)
    {
        const string sql = """
                           update atm_db.atm_users_bill
                           set money_bill = money_bill - :amount
                           where user_id = :userId;
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("userId", userId);
        command.AddParameter("amount", amount);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }
}