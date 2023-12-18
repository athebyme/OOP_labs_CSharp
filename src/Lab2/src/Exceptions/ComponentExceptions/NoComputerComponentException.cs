namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ComponentExceptions;

public class NoComputerComponentException : BaseException
{
    public NoComputerComponentException(string message)
        : base(message)
    {
    }

    public NoComputerComponentException()
    {
    }

    public NoComputerComponentException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}