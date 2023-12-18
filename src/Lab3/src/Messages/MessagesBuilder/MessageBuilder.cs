using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.MessageExceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.MessagesBuilder;

public class MessageBuilder : IMessageBuilder
{
    private MessageBody? _body;
    private MessageTitle? _title;
    private MessageImportance? _importance;
    public void WithTitle(MessageTitle messageTitle)
    {
        _title = messageTitle;
    }

    public void WithBody(MessageBody messageBody)
    {
        _body = messageBody;
    }

    public void WithImportanceStatus(MessageImportance messageImportanceCode)
    {
        _importance = messageImportanceCode;
    }

    public Message Build()
    {
        return new Message(
            _body ?? throw new MessageBodyUndefinedException(),
            _title ?? throw new NullMessageTitleException(),
            _importance ?? throw new MessageImportanceUndefinedException());
    }
}