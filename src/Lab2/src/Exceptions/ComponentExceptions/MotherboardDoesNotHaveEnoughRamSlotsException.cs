namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ComponentExceptions;

public class MotherboardDoesNotHaveEnoughRamSlotsException : BaseException
{
    public MotherboardDoesNotHaveEnoughRamSlotsException(string message)
        : base(message)
    {
    }

    public MotherboardDoesNotHaveEnoughRamSlotsException()
    {
    }

    public MotherboardDoesNotHaveEnoughRamSlotsException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}