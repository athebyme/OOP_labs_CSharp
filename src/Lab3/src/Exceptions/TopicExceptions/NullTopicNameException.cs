namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions.TopicExceptions;

public class NullTopicNameException : DefaultException
{
    public NullTopicNameException(string message)
        : base(message)
    {
    }

    public NullTopicNameException()
    {
    }

    public NullTopicNameException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}