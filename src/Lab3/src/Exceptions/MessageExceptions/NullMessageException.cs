namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions.MessageExceptions;

public class NullMessageException : DefaultException
{
    public NullMessageException(string message)
        : base(message)
    {
    }

    public NullMessageException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public NullMessageException()
    {
    }
}