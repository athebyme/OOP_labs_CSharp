namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions.TopicExceptions;

public class NullMediatorException : DefaultException
{
    public NullMediatorException(string message)
        : base(message)
    {
    }

    public NullMediatorException()
    {
    }

    public NullMediatorException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}