namespace Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions.VariableExceptions;

public class ArgumentIsNullException : StandardException
{
    public ArgumentIsNullException(string message)
        : base(message)
    {
    }

    public ArgumentIsNullException()
    {
    }

    public ArgumentIsNullException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}