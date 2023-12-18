using Atm.Users;
using Atm.Users.LoginResults;
using Spectre.Console;

namespace Atm.Scenarios.Login;

public class LoginScenario : IScenario
{
    private readonly IUserService _userService;

    public LoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Login";
    public UserRole RoleAvailability => UserRole.User;

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username");
        string password = AnsiConsole.Ask<string>("Enter your password");

        UserLoginResult result = _userService.Login(username, password);

        string message = result.LoginResultType switch
        {
            LoginResultType.Success => $"Successful login as {result.User?.Role.ToString()}",
            LoginResultType.Failed => "User not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        string? details = result.Details?.ToString();

        AnsiConsole.WriteLine(message + " " + details);
        AnsiConsole.Write("Ok");
    }
}