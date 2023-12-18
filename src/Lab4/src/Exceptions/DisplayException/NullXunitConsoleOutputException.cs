namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions.DisplayException;

public class NullXunitConsoleOutputException : DefaultException
{
    public NullXunitConsoleOutputException(string message)
        : base(message)
    {
    }

    public NullXunitConsoleOutputException()
    {
    }

    public NullXunitConsoleOutputException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}