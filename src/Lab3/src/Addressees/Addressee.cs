using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseeInstances;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseeValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.AddresseeExceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.MessageExceptions;
using Itmo.ObjectOrientedProgramming.Lab3.LLogger;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public abstract class Addressee : IAddressee, IAddresseeComponent
{
    private readonly List<MessageDetails> _messageHistory = new();
    private readonly List<IObserver> _observersList = new();

    protected Addressee(AddresseeId addresseeId)
    {
        if (addresseeId == null) throw new NullAddresseeIdException();
        if (addresseeId.ChatId < 0) throw new NullAddresseeIdException();
        AddresseeId = addresseeId;
    }

    public AddresseeId AddresseeId { get; }

    public int LastMessageId { get; } = 1;

    public virtual void ReceiveMessage(Message message, AddresseeUser msgFrom)
    {
        if (message == null) throw new NullMessageException();

        var msgDetails = new MessageDetails
        {
            Message = message,
            Addressee = this,
            Sender = msgFrom,
            SendingTime = DateTime.Now,
            Id = message.MessageId,
        };
        _messageHistory.Add(msgDetails);

        NotifyObservers(nameof(ReceiveMessage), msgDetails);
    }

    public IEnumerable<Message> GetNewMessages()
    {
        return _messageHistory.Select(details => details.Message).Where(message => !message.State.IsRead());
    }

    public IEnumerable<Message> GetAllMessages()
    {
        return _messageHistory.Select(details => details.Message);
    }

    public Message? GetMessageById(int msgId)
    {
        return _messageHistory.FirstOrDefault(x => x.Id == msgId).Message;
    }

    public void AttachObserver(IObserver observer)
    {
        _observersList.Add(observer);
    }

    public void DetachObserver(IObserver observer)
    {
        _observersList.Remove(observer);
    }

    private void NotifyObservers(string notifyText, MessageDetails message)
    {
        foreach (IObserver observer in _observersList)
        {
            observer.ShowMessage(notifyText, message);
        }
    }
}