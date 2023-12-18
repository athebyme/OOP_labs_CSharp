namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions.ValueExceptions;

public class NullConsoleColorException : DefaultException
{
    public NullConsoleColorException(string message)
        : base(message)
    {
    }

    public NullConsoleColorException()
    {
    }

    public NullConsoleColorException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}