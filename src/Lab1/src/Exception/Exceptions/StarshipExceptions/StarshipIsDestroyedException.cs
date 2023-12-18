namespace Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions.StarshipExceptions;

public class StarshipIsDestroyedException : StarshipException
{
    public StarshipIsDestroyedException(string message)
        : base(message)
    {
    }

    public StarshipIsDestroyedException(object what, object whom)
    : base($"{what} is destroyed by {whom}")
    {
    }

    public StarshipIsDestroyedException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public StarshipIsDestroyedException()
    {
    }
}