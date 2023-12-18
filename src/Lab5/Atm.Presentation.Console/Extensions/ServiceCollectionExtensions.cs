using Atm.Scenarios.AddUser;
using Atm.Scenarios.Deposit;
using Atm.Scenarios.Login;
using Atm.Scenarios.TransactionHistory;
using Atm.Scenarios.Withdraw;
using Microsoft.Extensions.DependencyInjection;

namespace Atm.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AddUserScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawScenarioProvider>();
        collection.AddScoped<IScenarioProvider, DepositScenarioProvider>();
        collection.AddScoped<IScenarioProvider, TransactionHistoryScenarioProvider>();

        return collection;
    }
}