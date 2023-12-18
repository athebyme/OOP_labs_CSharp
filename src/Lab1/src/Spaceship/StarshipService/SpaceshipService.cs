using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions.StarshipExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.StarshipService;

public class SpaceshipService
{
    private readonly ICollection<Spaceship> _spaceships;

    public SpaceshipService(IEnumerable<Spaceship> spaceships)
    {
        _spaceships = new List<Spaceship>(spaceships);
    }

    public Spaceship GetBestSpaceship(Environment.Environment environment)
    {
        if (environment is null)
        {
            throw new ArgumentNullException(nameof(environment), " is null");
        }

        Spaceship? bestChoice = null;

        foreach (Spaceship spaceship in _spaceships)
        {
            if (environment.HasSubChannel && !spaceship.CanJump()) continue;
            if (bestChoice == null || bestChoice.SpaceshipUtilCoefficientByRange(environment.Range) <
                    spaceship.SpaceshipUtilCoefficientByRange(environment.Range))
            {
                bestChoice = spaceship;
            }
        }

        if (bestChoice is null) throw new NoSuitableStarship($"There is no suitable starship in {_spaceships} for this environment");
        return bestChoice;
    }
}