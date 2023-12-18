using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.DisplayService;

public interface IDisplay
{
    void Show(string text);
    void LogError(Exception e);
    void ChangeConsoleColor(ConsoleColor newColor);
}