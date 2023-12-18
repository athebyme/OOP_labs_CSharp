namespace Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions.VariableExceptions;

public class ParameterIsOutOfAvailableRangeException : StandardException
{
    public ParameterIsOutOfAvailableRangeException(string message)
        : base(message)
    {
    }

    public ParameterIsOutOfAvailableRangeException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public ParameterIsOutOfAvailableRangeException()
    {
    }
}