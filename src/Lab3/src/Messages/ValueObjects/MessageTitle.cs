using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.MessageExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.ValueObjects;

public class MessageTitle
{
    public MessageTitle(string text)
    {
        Text = text ?? throw new NullMessageTitleException();
    }

    public string Text { get; }
}