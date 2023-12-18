namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions.TopicExceptions;

public class NullTopicException : DefaultException
{
    public NullTopicException(string message)
        : base(message)
    {
    }

    public NullTopicException()
    {
    }

    public NullTopicException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}