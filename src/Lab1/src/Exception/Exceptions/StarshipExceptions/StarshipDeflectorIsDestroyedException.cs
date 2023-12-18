namespace Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions.StarshipExceptions;

public class StarshipDeflectorIsDestroyedException : StarshipException
{
    public StarshipDeflectorIsDestroyedException(string message)
        : base(message)
    {
    }

    public StarshipDeflectorIsDestroyedException()
    {
    }

    public StarshipDeflectorIsDestroyedException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}