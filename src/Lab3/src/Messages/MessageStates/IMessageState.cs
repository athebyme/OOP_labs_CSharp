namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.MessageStates;

public interface IMessageState
{
    void MarkAsRead(Message message);
    void MarkAsUnread(Message message);
    bool IsRead();
}