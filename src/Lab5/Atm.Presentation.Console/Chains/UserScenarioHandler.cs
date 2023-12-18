using Atm.Users;

namespace Atm.Chains;

[RoleSpecificScenario(UserRole.User)]
public class UserScenarioHandler : IScenarioHandler
{
    private readonly IEnumerable<IScenario> _userScenarios;

    public UserScenarioHandler(IEnumerable<IScenario> userScenarios)
    {
        _userScenarios = userScenarios;
    }

    public Task<bool> HandleAsync(UserRole role)
    {
        if (role == UserRole.User)
        {
            foreach (IScenario scenario in _userScenarios.Where(s => s.RoleAvailability == UserRole.User))
            {
                scenario.Run();
            }

            return Task.FromResult(true);
        }

        return Task.FromResult(false);
    }
}