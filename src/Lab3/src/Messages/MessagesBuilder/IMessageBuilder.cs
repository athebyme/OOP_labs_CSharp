using Itmo.ObjectOrientedProgramming.Lab3.Builder;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.MessagesBuilder;

public interface IMessageBuilder : IBuilder<Message>
{
    void WithTitle(MessageTitle messageTitle);
    void WithBody(MessageBody messageBody);
    void WithImportanceStatus(MessageImportance messageImportanceCode);
}