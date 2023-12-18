namespace Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions.StarshipExceptions;

public class StarshipCrewIsDeadException : StarshipException
{
    public StarshipCrewIsDeadException(string message)
        : base(message)
    {
    }

    public StarshipCrewIsDeadException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public StarshipCrewIsDeadException()
    {
    }
}