namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions.TopicExceptions;

public class AddresseeCantSendMessageToSelfException : DefaultException
{
    public AddresseeCantSendMessageToSelfException(string message)
        : base(message)
    {
    }

    public AddresseeCantSendMessageToSelfException()
    {
    }

    public AddresseeCantSendMessageToSelfException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}