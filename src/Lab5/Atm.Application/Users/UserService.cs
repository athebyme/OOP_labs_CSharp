using Atm.Hashing;
using Atm.Repositories;
using Atm.Transactions;
using Atm.Users.LoginResults;
namespace Atm.Users;

internal class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly CurrentUserManager _currentUserManager;
    private readonly ITransactionRepository _transactionRepository;

    public UserService(IUserRepository userRepository, CurrentUserManager currentUserManager, ITransactionRepository transactionRepository)
    {
        _userRepository = userRepository;
        _currentUserManager = currentUserManager;
        _transactionRepository = transactionRepository;
    }

    public bool IsLoggedIn() => _currentUserManager.User != null;

    public UserLoginResult Login(string username, string password)
    {
        User? user = _userRepository.FindUserByUsernameAsync(username).Result;

        if (user is null)
        {
            return new UserLoginResult(user, LoginResultType.Failed, LoginResultFailedDetails.UserNotFound);
        }

        if (!HashService.VerifyPassword(password, user.HashPassword, user.Salt))
        {
            return new UserLoginResult(user, LoginResultType.Failed, LoginResultFailedDetails.IncorrectPassword);
        }

        _currentUserManager.SetUser(user);
        return new UserLoginResult(user, LoginResultType.Success, null);
    }

    public async Task AddUser(string username, string userPassword, UserRole userRole)
    {
        ArgumentNullException.ThrowIfNull(username);
        ArgumentNullException.ThrowIfNull(userPassword);
        await _userRepository.AddUser(username, userPassword, userRole).ConfigureAwait(false);
    }

    public async Task<IEnumerable<Transaction>> GetAllUserTransactions()
    {
        return await _transactionRepository.FindTransactionsByUserIdAsync(
            _currentUserManager.User?.Id ?? -1).ConfigureAwait(false);
    }
}