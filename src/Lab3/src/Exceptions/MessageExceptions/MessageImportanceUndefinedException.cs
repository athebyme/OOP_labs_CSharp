namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions.MessageExceptions;

public class MessageImportanceUndefinedException : DefaultException
{
    public MessageImportanceUndefinedException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public MessageImportanceUndefinedException(string message)
        : base(message)
    {
    }

    public MessageImportanceUndefinedException()
    {
    }
}