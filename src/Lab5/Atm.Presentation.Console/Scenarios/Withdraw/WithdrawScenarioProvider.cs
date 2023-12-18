using System.Diagnostics.CodeAnalysis;
using Atm.Bills;
using Atm.Users;

namespace Atm.Scenarios.Withdraw;

public class WithdrawScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserService _currentUser;
    private readonly IBillService _billService;

    public WithdrawScenarioProvider(
        ICurrentUserService currentUser,
        IBillService billService)
    {
        _currentUser = currentUser;
        _billService = billService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new WithdrawScenario(_billService);
        return true;
    }
}