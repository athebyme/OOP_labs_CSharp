namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ComponentExceptions;

public class ComputerCaseDoesNotFitsTheMotherboard : BaseException
{
    public ComputerCaseDoesNotFitsTheMotherboard(string message)
        : base(message)
    {
    }

    public ComputerCaseDoesNotFitsTheMotherboard(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public ComputerCaseDoesNotFitsTheMotherboard()
    {
    }
}