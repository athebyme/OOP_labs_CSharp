using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Strategies.MessageStateStrategy;

public interface IMessageStateStrategy
{
    void ChangeState(Message message);
}