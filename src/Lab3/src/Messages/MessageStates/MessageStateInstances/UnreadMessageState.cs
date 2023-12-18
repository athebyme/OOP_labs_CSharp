using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.MessageExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.MessageStates.MessageStateInstances;

public class UnreadMessageState : IMessageState
{
    public void MarkAsRead(Message message)
    {
        if (message == null) throw new NullMessageException();
        message.SetState(new ReadMessageState());
    }

    public void MarkAsUnread(Message message)
    {
    }

    public bool IsRead()
    {
        return false;
    }
}