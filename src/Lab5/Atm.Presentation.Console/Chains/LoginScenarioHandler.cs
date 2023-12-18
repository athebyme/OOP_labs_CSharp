using Atm.Scenarios.Login;
using Atm.Users;

namespace Atm.Chains;

[RoleSpecificScenario(UserRole.None)]
public class LoginScenarioHandler : IScenarioHandler
{
    private readonly LoginScenario _loginScenario;

    public LoginScenarioHandler(LoginScenario loginScenario)
    {
        _loginScenario = loginScenario;
    }

    public Task<bool> HandleAsync(UserRole role)
    {
        if (role != UserRole.None) return Task.FromResult(false);
        _loginScenario.Run();
        return Task.FromResult(true);
    }
}