using Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseeInstances;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;

namespace Itmo.ObjectOrientedProgramming.Lab3.Commands;

public class SendMessageCommand : ICommand
{
    private readonly ITopic _topic;
    private readonly Message _message;
    private readonly AddresseeUser _sender;

    public SendMessageCommand(ITopic topic, Message message, AddresseeUser sender)
    {
        _topic = topic;
        _message = message;
        _sender = sender;
    }

    public void Execute()
    {
        _topic.SendMessage(_message, _sender);
    }
}
