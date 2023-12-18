namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ComponentExceptions;

public class ComponentIsNotFoundException : BaseException
{
    public ComponentIsNotFoundException(string message)
        : base(message)
    {
    }

    public ComponentIsNotFoundException()
    {
    }

    public ComponentIsNotFoundException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}