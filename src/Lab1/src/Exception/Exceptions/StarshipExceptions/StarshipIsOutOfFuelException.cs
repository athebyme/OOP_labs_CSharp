namespace Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions.StarshipExceptions;

public class StarshipIsOutOfFuelException : StarshipException
{
    public StarshipIsOutOfFuelException()
    { }

    public StarshipIsOutOfFuelException(string message)
        : base(message)
    { }

    public StarshipIsOutOfFuelException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}