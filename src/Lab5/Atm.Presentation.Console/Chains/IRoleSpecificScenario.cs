using Atm.Users;

namespace Atm.Chains;

public interface IRoleSpecificScenario : IScenario
{
    UserRole TargetRole { get; }
}
