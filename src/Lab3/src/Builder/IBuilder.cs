namespace Itmo.ObjectOrientedProgramming.Lab3.Builder;

public interface IBuilder<out T>
{
    T Build();
}