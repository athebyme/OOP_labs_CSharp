namespace Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions.StarshipExceptions;

public abstract class StarshipException : StandardException
{
    protected StarshipException()
    { }

    protected StarshipException(string message)
        : base($"[!] {message}")
    { }

    protected StarshipException(string message, System.Exception innerException)
        : base($"[!] {message}", innerException)
    { }
}