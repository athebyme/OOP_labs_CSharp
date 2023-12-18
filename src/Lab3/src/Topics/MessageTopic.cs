using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseeInstances;
using Itmo.ObjectOrientedProgramming.Lab3.Commands;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.AddresseeExceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.TopicExceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Mediators;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public class MessageTopic : ITopic
{
    private readonly List<ICommand> _commands = new();
    private readonly TopicMediator _topicMediator;

    public MessageTopic(string name, Addressee addressee, TopicMediator topicMediator, int topicId)
    {
        Name = name ?? throw new NullTopicNameException();
        Addressee = addressee ?? throw new NullAddresseeException();
        _topicMediator = topicMediator ?? throw new NullMediatorException();
        TopicId = topicId;
    }

    public string Name { get; }
    public int TopicId { get; }
    public Addressee Addressee { get; }

    public void SendMessage(Message message, AddresseeUser messageFrom)
    {
        if (messageFrom == Addressee) throw new AddresseeCantSendMessageToSelfException();
        _topicMediator.SendMessage(TopicId, message, messageFrom);
    }

    public IEnumerable<Message>? CheckMessages()
    {
        IEnumerable<Message>? newMessages = _topicMediator.CheckMessages(TopicId);
        return newMessages;
    }

    public void AddCommand(ICommand command)
    {
        _commands.Add(command);
    }

    public void ExecuteCommands()
    {
        foreach (ICommand command in _commands)
        {
            command.Execute();
        }

        _commands.Clear();
    }
}
