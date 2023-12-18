namespace Atm.Users;

public interface ICurrentUserService
{
    User? User { get; }
}