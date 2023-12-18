using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions.VariableExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.SpaceBodies.SpaceBodyModels;
namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacle.SpaceBodies;

public class Cluster
{
    private readonly ICollection<SpaceBody> _cluster = new List<SpaceBody>();
    private readonly int _countAsteroids;
    private readonly int _countMeteorites;

    public Cluster(int countAsteroids, int countMeteorites)
    {
        if (countAsteroids < 0) throw new ParameterIsOutOfAvailableRangeException($"{nameof(countAsteroids)} is < 0 !");
        if (countMeteorites < 0) throw new ParameterIsOutOfAvailableRangeException($"{nameof(countMeteorites)} is < 0 !");

        ClusterSize = countAsteroids + countMeteorites;
        _countAsteroids = countAsteroids;
        _countMeteorites = countMeteorites;
        GenerateCluster();
    }

    private int ClusterSize { get; set; }
    public decimal TotalDamage() => _cluster.Sum(body => body.Damage.Value);
    private void GenerateAsteroids(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _cluster.Add(new Asteroid());
        }
    }

    private void GenerateMeteorites(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _cluster.Add(new Meteorite());
        }
    }

    private void GenerateCluster()
    {
        GenerateMeteorites(_countMeteorites);
        GenerateAsteroids(_countAsteroids);
    }
}