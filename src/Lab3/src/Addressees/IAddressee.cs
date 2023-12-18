using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseeInstances;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public interface IAddressee
{
    int LastMessageId { get; }
    void ReceiveMessage(Message message, AddresseeUser msgFrom);
    IEnumerable<Message> GetNewMessages();
    IEnumerable<Message> GetAllMessages();
    Message? GetMessageById(int msgId);
}