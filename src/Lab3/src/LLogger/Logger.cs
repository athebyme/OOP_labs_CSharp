using System;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.PermissionsSystem;
using Itmo.ObjectOrientedProgramming.Lab3.DisplayService;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.DisplayExceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using static Crayon.Output;
namespace Itmo.ObjectOrientedProgramming.Lab3.LLogger;

public class Logger : IObserver
{
    private static readonly string LoggedMsg = Bold().Cyan($"[Logged]");
    private IDisplayDriver _displayDriver;

    public Logger(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public void ChangeOutput(IDisplayDriver newOutput)
    {
        _displayDriver = newOutput ?? throw new NullConsoleOutputException();
    }

    public void ShowMessage(string text, MessageDetails message)
    {
        _displayDriver.Show($"{LoggedMsg} {Bold().Cyan(DateTime.Now + " ")} {text}: {message.Message}\nmsg_details:{message}");
    }

    public virtual void Show(string text)
    {
        _displayDriver.Show($"{LoggedMsg} {Bold().Cyan(DateTime.Now + " ")} {text}");
    }

    public virtual void HandleMessageStateChanged(Message message)
    {
        _displayDriver.Show($"{LoggedMsg} {Bold().Cyan(DateTime.Now + " ")}" + Yellow($"State changed\nmsg: {message}\nIsRead:{message?.State.IsRead()}"));
    }

    public virtual void HandleMessageSend(Addressee msgFrom, Message message, IAddressee msgTo)
    {
        _displayDriver.Show($"{LoggedMsg} {Bold().Cyan(DateTime.Now + " ")}" + Green($"Msg sent. From: {msgFrom}|To: {msgTo} \nmsg: {message}"));
    }

    public virtual void HandleUserHasNoPermission(Addressee user, Permissions permission)
    {
        _displayDriver.Show($"{LoggedMsg} {Bold().Cyan(DateTime.Now + " ")}" + Red($"User with ID: {user?.AddresseeId.ChatId} does not have {permission} permission"));
    }
}