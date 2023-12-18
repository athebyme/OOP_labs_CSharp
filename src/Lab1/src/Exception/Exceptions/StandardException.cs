namespace Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions;

public class StandardException : System.Exception
{
    public StandardException(string message)
        : base(message)
    {
    }

    public StandardException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public StandardException()
    {
    }
}