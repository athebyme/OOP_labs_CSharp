using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.AddresseeExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users.UserDecorators;

public class UserDecorator : User
{
    public UserDecorator(User user)
        : base(user?.Id ?? throw new NullUserException())
    {
        DecoratedUser = user;
    }

    public User DecoratedUser { get; }
}