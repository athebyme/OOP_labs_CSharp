using System.Globalization;
using Atm.Users;
using Spectre.Console;
using Transaction = Atm.Transactions.Transaction;

namespace Atm.Scenarios.TransactionHistory;

public class TransactionHistoryScenario : IScenario
{
    private readonly IUserService _userService;

    public TransactionHistoryScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "See transaction history";
    public UserRole RoleAvailability => UserRole.User;

    public void Run()
    {
        var userTransactions = _userService.GetAllUserTransactions().Result.ToList();
        foreach (Transaction transaction in userTransactions)
        {
            AnsiConsole.Write(transaction.TransactionType + transaction.BillState.ToString(CultureInfo.CurrentCulture) + transaction.Date);
        }

        AnsiConsole.Write("Ok");
    }
}