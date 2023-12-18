namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandParser;

public interface ICommand
{
    void Execute();
    void Undo();
}