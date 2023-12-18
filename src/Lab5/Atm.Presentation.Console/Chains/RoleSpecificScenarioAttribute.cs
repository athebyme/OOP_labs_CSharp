using Atm.Users;

namespace Atm.Chains;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class RoleSpecificScenarioAttribute : Attribute
{
    public RoleSpecificScenarioAttribute(UserRole targetRole)
    {
        TargetRole = targetRole;
    }

    public UserRole TargetRole { get; }
}
