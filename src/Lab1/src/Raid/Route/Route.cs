namespace Itmo.ObjectOrientedProgramming.Lab1.Raid.Route;

public abstract class Route
{
    public abstract int Range { get; protected set; }
    public abstract Environment.Environment Environment { get; private protected set; }
    public decimal GetRouteColonyDamage() => Environment.ColonyDamage();
}