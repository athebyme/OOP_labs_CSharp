namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions.MessageExceptions;

public class MessageTitleUndefinedException : DefaultException
{
    public MessageTitleUndefinedException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public MessageTitleUndefinedException(string message)
        : base(message)
    {
    }

    public MessageTitleUndefinedException()
    {
    }
}