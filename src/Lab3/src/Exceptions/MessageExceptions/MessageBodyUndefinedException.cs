namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions.MessageExceptions;

public class MessageBodyUndefinedException : DefaultException
{
    public MessageBodyUndefinedException(string message)
        : base(message)
    {
    }

    public MessageBodyUndefinedException()
    {
    }

    public MessageBodyUndefinedException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}