using Atm.Bills;
using Atm.Users;
using Spectre.Console;

namespace Atm.Scenarios.Deposit;

public class DepositScenario : IScenario
{
    private readonly IUserService _userService;
    private readonly IBillService _billService;

    public DepositScenario(IUserService userService, IBillService billService)
    {
        _userService = userService;
        _billService = billService;
    }

    public string Name => "Deposit";
    public UserRole RoleAvailability => UserRole.User;

    public void Run()
    {
        int moneyAmount = AnsiConsole.Ask<int>("Enter depositing amount of money");
        _billService.WithdrawMoney(moneyAmount);
    }
}