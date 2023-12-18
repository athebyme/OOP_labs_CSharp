using Atm.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace Atm;

public static class Program
{
    public static void Main()
    {
        var collection = new ServiceCollection();
        collection
            .AddApplication()
            .AddInfrastructureDataAccess(configuration =>
            {
                configuration.Host = "localhost";
                configuration.Port = 5432;
                configuration.Username = "postgres";
                configuration.Password = "postgres";
                configuration.Database = "atm_db";
                configuration.SslMode = "Prefer";
            })
            .AddPresentationConsole();
        ServiceProvider provider = collection.BuildServiceProvider();
        using IServiceScope scope = provider.CreateScope();
        ScenarioRunner scenarioRunner = scope.ServiceProvider
            .GetRequiredService<ScenarioRunner>();
        while (true)
        {
            scenarioRunner.Run();
            AnsiConsole.Clear();
        }
    }
}