using Atm.Bills;
using Atm.Hashing;
using Atm.Users;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace Atm.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider ?? throw new ArgumentNullException(nameof(connectionProvider));
    }

    public async Task<User?> FindUserByUsernameAsync(string username)
    {
        const string userSql = @"
        select user_id, user_name, user_role, user_password, user_salt
        from atm_db.atm_users
        where user_name = :username;
    ";

        using NpgsqlConnection connection =
            await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using var userCommand = new NpgsqlCommand(userSql, connection);
        userCommand.AddParameter("username", username);

        using NpgsqlDataReader userReader =
            await userCommand.ExecuteReaderAsync().ConfigureAwait(false);

        if (await userReader.ReadAsync().ConfigureAwait(false) is false)
            return null;

        int userId = userReader.GetInt32(0);
        Bill? result = await FindUserBillById(userId).ConfigureAwait(false);

        if (result == null)
        {
            return null;
        }

        return new User(
            Id: userId,
            Username: userReader.GetString(1),
            Role: (UserRole)userReader.GetInt32(2),
            HashPassword: userReader.GetString(3),
            Salt: userReader.GetString(4),
            Bill: result);
    }

    public async Task AddUser(string username, string password, UserRole role)
    {
        const string userSql = """
                               INSERT INTO atm_db.atm_users(user_name, user_role, user_password, user_salt)
                               VALUES (@username, @role, @password, @salt)
                               RETURNING user_id;
                               """;

        const string billSql = """
                               INSERT INTO atm_db.atm_users_bill(user_id, money_bill)
                               VALUES (@userId, 0);
                               """;

        string salt = SaltGenerator.GenerateSalt();
        string hashedPassword = HashService.HashPasswordWithSalt(password + salt);

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using (NpgsqlTransaction transaction = await connection.BeginTransactionAsync().ConfigureAwait(false))
        {
            try
            {
                int userId;
                using (var command = new NpgsqlCommand(userSql, connection))
                {
                    command.Transaction = transaction;

                    command.AddParameter("username", username);
                    command.AddParameter("role", (int)role);
                    command.AddParameter("password", hashedPassword);
                    command.AddParameter("salt", salt);

                    userId = (int)(await command.ExecuteScalarAsync().ConfigureAwait(false) ?? -1);
                }

                using (var command = new NpgsqlCommand(billSql, connection))
                {
                    command.Transaction = transaction;

                    command.AddParameter("userId", userId);

                    await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                }

                await transaction.CommitAsync().ConfigureAwait(false);
            }
            catch (NpgsqlException)
            {
                await transaction.RollbackAsync().ConfigureAwait(false);
            }
        }
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

    public async Task<Bill?> FindUserBillById(int userId)
    {
        const string billSql = @"
        select user_id, money_bill
        from atm_db.atm_users_bill
        where user_id = :userId;
    ";

        using NpgsqlConnection connection2 =
            await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using var billCommand = new NpgsqlCommand(billSql, connection2);
        billCommand.AddParameter("userId", userId);

        using NpgsqlDataReader billReader =
            await billCommand.ExecuteReaderAsync().ConfigureAwait(false);

        return await billReader.ReadAsync().ConfigureAwait(false) is false
            ? null
            : new Bill(userId, billReader.GetInt32(1));
    }
}