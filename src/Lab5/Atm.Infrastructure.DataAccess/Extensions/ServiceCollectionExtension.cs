using Atm.Migrations;
using Atm.Plugins;
using Atm.Repositories;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Processors;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Itmo.Dev.Platform.Postgres.Plugins;
using Microsoft.Extensions.DependencyInjection;

namespace Atm.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection collection,
        Action<PostgresConnectionConfiguration> configuration)
    {
        collection.AddPlatformPostgres(builder => builder.Configure(configuration));
        collection.AddPlatformMigrations(typeof(ServiceCollectionExtensions).Assembly);

        collection.AddSingleton<IDataSourcePlugin, MappingPlugin>();

        collection.AddScoped<IUserRepository, UserRepository>();
        collection.AddScoped<ITransactionRepository, TransactionRepository>();
        collection.AddScoped<IBillRepository, BillRepository>();
        collection.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddPostgres()
                .WithGlobalConnectionString("Host=localhost;Port=5432;Database=atm_db;Username=postgres;Password=postgres;")
                .ScanIn(typeof(Migration13122023).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .Configure<SelectingProcessorAccessorOptions>(options => options.ProcessorId = "Postgres");
        collection.BuildServiceProvider().GetRequiredService<IMigrationRunner>().MigrateUp();
        return collection;
    }
}