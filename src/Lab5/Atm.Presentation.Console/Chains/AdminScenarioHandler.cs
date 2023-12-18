using Atm.Users;

namespace Atm.Chains;

[RoleSpecificScenario(UserRole.Admin)]
public class AdminScenarioHandler : IScenarioHandler
{
    private readonly IEnumerable<IScenario> _adminScenarios;

    public AdminScenarioHandler(IEnumerable<IScenario> adminScenarios)
    {
        _adminScenarios = adminScenarios;
    }

    public Task<bool> HandleAsync(UserRole role)
    {
        if (role == UserRole.Admin)
        {
            foreach (IScenario scenario in _adminScenarios.Where(s => s.RoleAvailability == UserRole.Admin))
            {
                scenario.Run();
            }

            return Task.FromResult(true);
        }

        return Task.FromResult(false);
    }
}