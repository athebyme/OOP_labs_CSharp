using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions.VariableExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Creatures.Colony;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.SpaceBodies;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.SpecialEvents;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentsModels.NebulaModels;

public class IncreasedDensityNebula : Nebula
{
    public IncreasedDensityNebula(int range, int colonySize, int countAsteroid, int countMeteorite, bool hasSpecialEvent)
        : base(range)
    {
        if (range < 0) throw new ParameterIsOutOfAvailableRangeException($"{nameof(range)} is < 0 !");
        if (colonySize < 0) throw new ParameterIsOutOfAvailableRangeException($"{nameof(colonySize)} is < 0 !");
        if (countAsteroid < 0) throw new ParameterIsOutOfAvailableRangeException($"{nameof(countAsteroid)} is < 0 !");
        if (countMeteorite < 0) throw new ParameterIsOutOfAvailableRangeException($"{nameof(countMeteorite)} is < 0 !");

        SubspaceChannels = new ReadOnlyCollection<SubspaceChannel>(new[] { new SubspaceChannel(Range, true, hasSpecialEvent, SpecialEventsType.Flash) });
        Colony = new Colony(colonySize);
        Cluster = new Cluster(countAsteroid, countMeteorite);
    }

    public override bool HasSubChannel => true;
    protected sealed override Colony Colony { get; set; }
    protected sealed override IReadOnlyCollection<SubspaceChannel> SubspaceChannels { get; set; }
    protected sealed override Cluster Cluster { get; set; }
}