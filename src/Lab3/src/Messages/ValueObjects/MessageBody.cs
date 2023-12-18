using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.MessageExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.ValueObjects;

public class MessageBody
{
    public MessageBody(string text)
    {
        Text = text ?? throw new NullMessageException();
    }

    public string Text { get; }
}