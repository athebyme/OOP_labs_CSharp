namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions.DisplayExceptions;

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