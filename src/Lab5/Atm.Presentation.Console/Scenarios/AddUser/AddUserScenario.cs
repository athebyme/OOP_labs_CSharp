using Atm.Users;
using Spectre.Console;

namespace Atm.Scenarios.AddUser;

public class AddUserScenario : IScenario
{
    private readonly IUserService _userService;
    public AddUserScenario(IUserService userService)
    {
        _userService = userService;
    }

    public UserRole RoleAvailability => UserRole.Admin;

    public string Name => "Add user";

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter user username");
        string password = AnsiConsole.Ask<string>("Enter user password");
        string roleStr = AnsiConsole.Ask<string>("Enter user role");

        if (Enum.TryParse(roleStr, true, out UserRole role))
        {
            _userService.AddUser(username, password, role);

            AnsiConsole.WriteLine("User added successfully!");
            AnsiConsole.Write("Ok");
        }
        else
        {
            AnsiConsole.WriteLine($"Invalid role: {roleStr}. Please enter a valid role.");
        }
    }
}