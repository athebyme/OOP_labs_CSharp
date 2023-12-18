using System;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseeInstances;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.MessageStateHandler;

public class MessageSendEventArgs : EventArgs
{
    public MessageSendEventArgs(Message message, AddresseeUser messageFrom, IAddressee messageTo)
    {
        Message = message;
        MessageFrom = messageFrom;
        MessageTo = messageTo;
    }

    public Message Message { get; }
    public AddresseeUser MessageFrom { get; }
    public IAddressee MessageTo { get; }
}
