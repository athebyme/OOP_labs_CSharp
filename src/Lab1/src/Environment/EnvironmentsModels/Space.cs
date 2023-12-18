using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions.VariableExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Creatures.Colony;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.SpaceBodies;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentsModels;

public class Space : Environment
{
    public Space(int range, int countAsteroid, int countMeteorite, bool hasSpecialEvent)
    {
        if (range < 0) throw new ParameterIsOutOfAvailableRangeException($"{nameof(range)} is < 0 !");
        if (countAsteroid < 0) throw new ParameterIsOutOfAvailableRangeException($"{nameof(countAsteroid)} is < 0 !");
        if (countMeteorite < 0) throw new ParameterIsOutOfAvailableRangeException($"{nameof(countMeteorite)} is < 0 !");

        Range = range;
        SubspaceChannels = new ReadOnlyCollection<SubspaceChannel>(new[] { new SubspaceChannel(Range, false, hasSpecialEvent, null) });
        Cluster = new Cluster(countAsteroid, countMeteorite);
        IsWarpRequired = false;
    }

    public override bool HasSubChannel => false;
    protected override Colony Colony { get; set; } = new();
    protected sealed override IReadOnlyCollection<SubspaceChannel> SubspaceChannels { get; set; }
    protected sealed override Cluster Cluster { get; set; }
}