using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentsModels;
using Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions.VariableExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Creatures.Colony;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.SpaceBodies;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public abstract class Environment
{
    public int Range { get; protected init; }
    public bool IsWarpRequired { get; private protected init; }
    public abstract bool HasSubChannel { get; }
    protected abstract Colony Colony { get; set; }
    protected abstract IReadOnlyCollection<SubspaceChannel> SubspaceChannels { get; set; }
    protected abstract Cluster Cluster { get; set; }
    public decimal ColonyDamage() => Colony.ColonyTotalDamage();
    public decimal ClusterDamage() => Cluster.TotalDamage();
    public SubspaceChannel GetSubspaceChannel(int index)
    {
        if (index < 0 || index >= SubspaceChannels.Count) throw new ParameterIsOutOfAvailableRangeException($"{nameof(index)} param has to be > 0 and < {SubspaceChannels.Count - 1}");
        return SubspaceChannels.ElementAt(index);
    }
}