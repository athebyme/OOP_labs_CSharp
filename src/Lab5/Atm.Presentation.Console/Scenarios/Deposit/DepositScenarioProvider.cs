using System.Diagnostics.CodeAnalysis;
using Atm.Bills;
using Atm.Users;

namespace Atm.Scenarios.Deposit;

public class DepositScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;
    private readonly IBillService _billService;

    public DepositScenarioProvider(
        IUserService service,
        ICurrentUserService currentUser,
        IBillService billService)
    {
        _service = service;
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

        scenario = new DepositScenario(_service, _billService);
        return true;
    }
}