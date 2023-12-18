using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.ValueExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.ValueObjects;

public class MessageImportance
{
    public MessageImportance(int importanceCode)
    {
        if (importanceCode < 0) throw new ValueOutOfRangeException();
        ImportanceCode = importanceCode;
    }

    public int ImportanceCode { get; }
}