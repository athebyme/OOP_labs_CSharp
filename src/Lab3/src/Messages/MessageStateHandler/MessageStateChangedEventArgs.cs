using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.MessageStateHandler;

public class MessageStateChangedEventArgs : EventArgs
{
    public MessageStateChangedEventArgs(Message message)
    {
        Message = message;
    }

    public Message Message { get; }
}