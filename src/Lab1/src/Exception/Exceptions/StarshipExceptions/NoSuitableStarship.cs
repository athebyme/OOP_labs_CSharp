namespace Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions.StarshipExceptions;

public class NoSuitableStarship : StarshipException
{
    public NoSuitableStarship(string message)
        : base(message)
    {
    }

    public NoSuitableStarship()
    {
    }

    public NoSuitableStarship(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}