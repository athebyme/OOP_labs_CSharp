namespace Itmo.ObjectOrientedProgramming.Lab3.Prototypes;

public interface ICloneable<out T>
{
    T Clone();
}