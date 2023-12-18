namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandHandlers;

public interface ICommandHandler
{
    ICommandHandler SetNext(ICommandHandler nextHandler);
    CommandHandler Handle(ref string[] args);
}