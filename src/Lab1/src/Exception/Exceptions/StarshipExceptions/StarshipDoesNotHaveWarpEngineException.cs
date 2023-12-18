namespace Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions.StarshipExceptions;

public class StarshipDoesNotHaveWarpEngineException : StarshipException
{
    public StarshipDoesNotHaveWarpEngineException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public StarshipDoesNotHaveWarpEngineException()
    {
    }

    public StarshipDoesNotHaveWarpEngineException(string message)
        : base(message)
    {
    }
}