using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.LLogger;

public interface IObserver
{
    void ShowMessage(string text, MessageDetails message);
}