using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions.VariableExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Creatures.CreatureModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Creatures.Colony;

public class Colony
{
    private static int _colonySize;
    private readonly List<Creature> _colony = new(_colonySize);
    private readonly Creature _creature;
    public Colony(Creature creature, int colonySize)
    {
        if (colonySize < 0) throw new ParameterIsOutOfAvailableRangeException($"{nameof(colonySize)} is < 0 !");
        _colonySize = colonySize;
        _creature = creature ?? throw new ArgumentIsNullException($"{nameof(colonySize)} cant be null !");
        CreateColony(colonySize);
    }

    public Colony(int colonySize)
    {
        if (colonySize < 0) throw new ParameterIsOutOfAvailableRangeException($"{nameof(colonySize)} is < 0 !");
        _colonySize = colonySize;
        _creature = new SpaceWhales();
        CreateColony(colonySize);
    }

    public Colony()
    {
        _creature = new SpaceWhales();
    }

    private bool IsColonyEmpty { get; set; } = true;
    public decimal ColonyTotalDamage() => !IsColonyEmpty ? (_colony.Count * _creature.Damage.Value) : 0;
    public string CreatureType() => !IsColonyEmpty ? _creature.GetType().Name : "This colony has no alive creatures";
    private void CreateColony(int colonySize)
    {
        for (int i = 0; i < colonySize; ++i)
        {
            _colony.Add(_creature);
        }

        IsColonyEmpty = false;
    }
}