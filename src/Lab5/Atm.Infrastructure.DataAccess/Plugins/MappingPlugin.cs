using Atm.Users;
using Itmo.Dev.Platform.Postgres.Plugins;
using Npgsql;

namespace Atm.Plugins;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder)
    {
        builder?.MapEnum<UserRole>();
    }
}