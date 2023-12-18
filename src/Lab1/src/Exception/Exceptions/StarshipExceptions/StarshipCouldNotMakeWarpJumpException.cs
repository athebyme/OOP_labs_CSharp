namespace Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions.StarshipExceptions;

public class StarshipCouldNotMakeWarpJumpException : StarshipException
{
    public StarshipCouldNotMakeWarpJumpException(string message)
        : base(message)
    {
    }

    public StarshipCouldNotMakeWarpJumpException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public StarshipCouldNotMakeWarpJumpException()
    {
    }
}