namespace Atm.Users;

internal class CurrentUserManager : ICurrentUserService
{
    public User? User { get; private set; }

    public void SetUser(User newUser)
    {
        User = newUser;
    }
}