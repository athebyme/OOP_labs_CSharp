namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions.MessageExceptions;

public class NullImportanceCodeException : DefaultException
{
    public NullImportanceCodeException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public NullImportanceCodeException()
    {
    }

    public NullImportanceCodeException(string message)
        : base(message)
    {
    }
}