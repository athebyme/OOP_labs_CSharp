using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.MessageExceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Commands;

public class MarkAsReadCommand : ICommand
{
    private readonly List<Message> _messages;

    public MarkAsReadCommand(IEnumerable<Message>? message)
    {
        _messages = message?.ToList() ?? throw new NullMessageException();
    }

    public void Execute()
    {
        foreach (Message msg in _messages)
        {
            msg.State.MarkAsRead(msg);
        }
    }
}