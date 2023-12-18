namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions.DisplayException;

public class NullConsoleOutputException : DefaultException
{
    public NullConsoleOutputException(string message)
        : base(message)
    {
    }

    public NullConsoleOutputException()
    {
    }

    public NullConsoleOutputException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}