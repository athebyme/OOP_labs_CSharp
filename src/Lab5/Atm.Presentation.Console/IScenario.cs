using Atm.Users;

namespace Atm;

public interface IScenario
{
    string Name { get; }
    UserRole RoleAvailability { get; }
    void Run();
}