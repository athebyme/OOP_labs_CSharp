using Atm.Bills;
using Atm.Users;
using Spectre.Console;

namespace Atm.Scenarios.Withdraw;

public class WithdrawScenario : IScenario
{
    private readonly IBillService _billService;

    public WithdrawScenario(IBillService billService)
    {
        _billService = billService;
    }

    public string Name => "Withdraw";
    public UserRole RoleAvailability => UserRole.User;

    public void Run()
    {
        int moneyAmount = AnsiConsole.Ask<int>("Enter withdrawing amount of money");
        _billService.WithdrawMoney(moneyAmount);
    }
}