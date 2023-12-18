using Atm.Users;

namespace Atm.Chains;

public interface IScenarioHandler
{
    Task<bool> HandleAsync(UserRole role);
}