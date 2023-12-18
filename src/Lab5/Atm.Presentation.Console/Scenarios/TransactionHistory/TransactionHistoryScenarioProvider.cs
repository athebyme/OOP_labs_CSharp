using System.Diagnostics.CodeAnalysis;
using Atm.Users;

namespace Atm.Scenarios.TransactionHistory;

public class TransactionHistoryScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly ICurrentUserService _currentUser;

    public TransactionHistoryScenarioProvider(
        ICurrentUserService currentUser,
        IUserService userService)
    {
        _currentUser = currentUser;
        _userService = userService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new TransactionHistoryScenario(_userService);
        return true;
    }
}