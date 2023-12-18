namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions.MessageExceptions;

public class NullMessageStateException : DefaultException
{
    public NullMessageStateException(string message)
        : base(message)
    {
    }

    public NullMessageStateException()
    {
    }

    public NullMessageStateException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}