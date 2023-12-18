namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ComponentExceptions;

public class MotherBoardDoesNotHaveEnoughDrivePorts : BaseException
{
    public MotherBoardDoesNotHaveEnoughDrivePorts(string message)
        : base(message)
    {
    }

    public MotherBoardDoesNotHaveEnoughDrivePorts()
    {
    }

    public MotherBoardDoesNotHaveEnoughDrivePorts(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}