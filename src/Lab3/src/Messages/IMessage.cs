using Itmo.ObjectOrientedProgramming.Lab3.Messages.MessageStates;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public interface IMessage
{
    int MessageId { get; }
    MessageBody Body { get; }
    MessageTitle Title { get; }
    MessageImportance ImportanceCode { get; }
    IMessageState State { get; }
}