using Itmo.ObjectOrientedProgramming.Lab3.Users.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public interface IUser
{
    UserId UserId { get; }
}