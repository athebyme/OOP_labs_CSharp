using Atm.Users;

namespace Atm.Chains;

public class RoleSpecificScenarioHandler : IScenarioHandler
{
    private readonly IEnumerable<IRoleSpecificScenario> _roleSpecificScenarios;

    public RoleSpecificScenarioHandler(IEnumerable<IRoleSpecificScenario> roleSpecificScenarios)
    {
        _roleSpecificScenarios = roleSpecificScenarios;
    }

    public Task<bool> HandleAsync(UserRole role)
    {
        foreach (IRoleSpecificScenario scenario in _roleSpecificScenarios.Where(s => s.TargetRole == role || s.TargetRole == UserRole.None))
        {
            scenario.Run();
        }

        return Task.FromResult(true);
    }
}