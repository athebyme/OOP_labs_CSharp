using Atm.Users;

namespace Atm.Repositories;

public interface IUserRepository
{
    Task<User?> FindUserByUsernameAsync(string username);
    Task AddUser(string username, string password, UserRole role);
}