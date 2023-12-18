using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.AddresseeExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseeValueObjects;

public class AddresseeId
{
    public AddresseeId(int chatId)
    {
        if (chatId < 0)
            throw new ChatIdCantBeBelowZeroException();
        ChatId = chatId;
    }

    public int ChatId { get; }
}