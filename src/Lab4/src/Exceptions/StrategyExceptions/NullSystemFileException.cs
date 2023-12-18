namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions.StrategyExceptions;

public class NullSystemFileException : DefaultException
{
    public NullSystemFileException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public NullSystemFileException()
    {
    }

    public NullSystemFileException(string message)
        : base(message)
    {
    }
}