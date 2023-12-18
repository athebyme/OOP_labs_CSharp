namespace Atm.Users.LoginResults;

public record UserLoginResult(User? User, LoginResultType LoginResultType, LoginResultFailedDetails? Details);