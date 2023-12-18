namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions.MessageExceptions;

public class NullMessageBodyException : DefaultException
{
    public NullMessageBodyException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public NullMessageBodyException()
    {
    }

    public NullMessageBodyException(string message)
        : base(message)
    {
    }
}