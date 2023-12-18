namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions.MessageExceptions;

public class NullMessageTitleException : DefaultException
{
    public NullMessageTitleException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public NullMessageTitleException()
    {
    }

    public NullMessageTitleException(string message)
        : base(message)
    {
    }
}