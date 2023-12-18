using System;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.MessageExceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.MessageStateHandler;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.MessageStates;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.MessageStates.MessageStateInstances;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;
public class Message : IMessage, ICloneable<Message>
{
    public Message(MessageBody body, MessageTitle? title, MessageImportance importanceCode)
    {
        Body = body ?? throw new NullMessageBodyException();
        Title = title ?? throw new NullMessageTitleException();
        ImportanceCode = importanceCode ?? throw new NullImportanceCodeException();
    }

    public event EventHandler<MessageStateChangedEventArgs>? MessageStateChanged;

    public int MessageId { get; private set; } = -1;
    public MessageBody Body { get; }
    public MessageTitle Title { get; }
    public MessageImportance ImportanceCode { get; }
    public IMessageState State { get; private set; } = new UnreadMessageState();

    public void SetState(IMessageState newMsgState)
    {
        State = newMsgState ?? throw new NullMessageStateException();
        OnMessageStateChanged();
    }

    public Message Clone()
    {
        return new Message(
            Body,
            Title,
            ImportanceCode);
    }

    public override string ToString() => $"{Title.Text}\n{Body.Text}";

    public void SetMsgId(int newId)
    {
        MessageId = newId;
    }

    protected virtual void OnMessageStateChanged()
    {
        MessageStateChanged?.Invoke(this, new MessageStateChangedEventArgs(this));
    }
}