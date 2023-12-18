using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseeInstances;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseeProxies;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.PermissionsSystem;
using Itmo.ObjectOrientedProgramming.Lab3.CustomStructures;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.TopicExceptions;
using Itmo.ObjectOrientedProgramming.Lab3.LLogger;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;

namespace Itmo.ObjectOrientedProgramming.Lab3.Mediators;

public class TopicMediator
{
    private readonly CustomDictionaryRealization<MessageTopic> _topics = new(100);

    public TopicMediator(LoggingAddresseeProxy proxy, ref PermissionSystem permissionSystem)
    {
        Proxy = proxy;
        AccessControlSystem = new AccessControlSystem(ref permissionSystem);
    }

    public AccessControlSystem AccessControlSystem { get; }

    private LoggingAddresseeProxy Proxy { get; set; }
    public void RegisterTopic(MessageTopic messageTopic)
    {
        if (messageTopic == null)
            throw new NullTopicException();
        _topics.Add(messageTopic.TopicId, messageTopic);
    }

    public void SendMessage(int topicId, Message message, AddresseeUser messageFrom)
    {
        if (_topics.Get(topicId) == default)
            throw new InvalidTopicIdException();
        if (!AccessControlSystem.CheckWritePermission(messageFrom)) return;

        Proxy.ReceiveMessage(message, messageFrom);
    }

    public IEnumerable<Message>? CheckMessages(int topicId)
    {
        MessageTopic messageTopic = _topics.Get(topicId) ?? throw new InvalidTopicIdException();
        return !AccessControlSystem.CheckReadPermission(messageTopic.Addressee.AddresseeId.ChatId, messageTopic.Addressee)
            ? default : messageTopic.Addressee.GetNewMessages();
    }
}