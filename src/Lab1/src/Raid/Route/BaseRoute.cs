using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Raid.Route;

public class BaseRoute : Route
{
    public BaseRoute(Environment.Environment environment)
    {
        if (environment is null) throw new ArgumentNullException(nameof(environment), $" is < 0 !");
        Range = environment.Range;
        Environment = environment;
    }

    public sealed override int Range { get; protected set; }
    public sealed override Environment.Environment Environment { get; private protected set; }
}