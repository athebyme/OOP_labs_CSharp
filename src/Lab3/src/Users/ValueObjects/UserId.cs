using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.ValueExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users.ValueObjects;

public class UserId
{
    public UserId(int id)
    {
        if (id < 0) throw new ValueOutOfRangeException();
        Id = id;
    }

    public int Id { get; }
}