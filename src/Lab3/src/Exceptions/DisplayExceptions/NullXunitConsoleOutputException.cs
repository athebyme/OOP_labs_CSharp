namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions.DisplayExceptions;

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