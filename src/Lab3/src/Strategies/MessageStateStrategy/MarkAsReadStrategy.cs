using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.MessageExceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Strategies.MessageStateStrategy;

public class MarkAsReadStrategy : IMessageStateStrategy
{
    public void ChangeState(Message message)
    {
        if (message == null) throw new NullMessageException();
        message.State.MarkAsRead(message);
    }
}