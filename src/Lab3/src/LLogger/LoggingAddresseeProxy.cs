using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseeInstances;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.AddresseeExceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.MessageExceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.MessageStateHandler;

namespace Itmo.ObjectOrientedProgramming.Lab3.LLogger;

public class LoggingAddresseeProxy : IAddressee
{
    private IAddressee _realAddressee;

    public LoggingAddresseeProxy(IAddressee realAddressee)
    {
        _realAddressee = realAddressee;
    }

    public event EventHandler<MessageSendEventArgs>? MessageSend;

    public int LastMessageId { get; private set; } = 1;

    public void ReceiveMessage(Message message, AddresseeUser msgFrom)
    {
        if (message == null) throw new NullMessageException();
        if (msgFrom == null) throw new NullAddresseeException();

        MessageSend?.Invoke(this, new MessageSendEventArgs(message, msgFrom, _realAddressee));

        message.SetMsgId(LastMessageId++);
        _realAddressee.ReceiveMessage(message, msgFrom);
    }

    public IEnumerable<Message> GetNewMessages()
    {
        return _realAddressee.GetNewMessages();
    }

    public IEnumerable<Message> GetAllMessages()
    {
        return _realAddressee.GetAllMessages();
    }

    public Message? GetMessageById(int msgId)
    {
        return _realAddressee.GetMessageById(msgId);
    }
}