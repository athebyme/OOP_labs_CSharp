using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayService;

public interface IDisplay
{
    void DisplayMessage(Message message);
    void DisplayError(Exception e);
    void ChangeConsoleColor(ConsoleColor newColor);
}