using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.MessageExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.MessageStates.MessageStateInstances;

public class ReadMessageState : IMessageState
{
    public void MarkAsRead(Message message)
    {
    }

    public void MarkAsUnread(Message message)
    {
        if (message == null) throw new NullMessageException();
        message.SetState(new UnreadMessageState());
    }

    public bool IsRead()
    {
        return true;
    }
}