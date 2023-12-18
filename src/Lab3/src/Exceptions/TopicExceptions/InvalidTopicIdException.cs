namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions.TopicExceptions;

public class InvalidTopicIdException : DefaultException
{
    public InvalidTopicIdException(string message)
        : base(message)
    {
    }

    public InvalidTopicIdException()
    {
    }

    public InvalidTopicIdException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}