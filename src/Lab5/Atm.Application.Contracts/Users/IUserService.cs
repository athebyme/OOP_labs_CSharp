using Atm.Transactions;
using Atm.Users.LoginResults;

namespace Atm.Users;

public interface IUserService
{
    UserLoginResult Login(string username, string password);
    Task<IEnumerable<Transaction>> GetAllUserTransactions();
    Task AddUser(string username, string userPassword, UserRole userRole);
}