using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentsModels;
using Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions.StarshipExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions.VariableExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.SpecialEvents;
using Itmo.ObjectOrientedProgramming.Lab1.Raid.RaidResults;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.StarshipService;

namespace Itmo.ObjectOrientedProgramming.Lab1.Raid;

public class RaidService
{
    private readonly IReadOnlyCollection<Route.Route>? _routes;
    private SpaceshipService? _spaceshipService;

    public RaidService(
        IReadOnlyCollection<Spaceship.Spaceship> spaceships,
        IReadOnlyCollection<Route.Route> routes)
    {
        if (spaceships is null) throw new ArgumentNullException(nameof(spaceships), "is null");
        if (routes is null) throw new ArgumentNullException(nameof(routes), "is null");
        _spaceshipService = new SpaceshipService(spaceships);
        _routes = routes.ToList();
    }

    public RaidService(IReadOnlyCollection<Route.Route> routes)
    {
        _routes = routes;
    }

    public Results StartRaid()
    {
        if (_routes == null) throw new ArgumentIsNullException($"Routes are empty !");
        if (_spaceshipService == null) throw new ArgumentIsNullException($"Starships are empty !");
        Spaceship.Spaceship? chosenSpaceship = null;
        foreach (Route.Route route in _routes)
        {
            try
            {
                chosenSpaceship = _spaceshipService.GetBestSpaceship(route.Environment);
                RaidPreparing(chosenSpaceship, route);
                PassRoute(chosenSpaceship, route);
            }
            catch (StarshipDoesNotHaveWarpEngineException)
            {
                return new Results(chosenSpaceship, ResultType.Unsuccessful, ResultTypeAddiction.NoWarpEngines);
            }
            catch (StarshipCouldNotMakeWarpJumpException)
            {
                return new Results(chosenSpaceship, ResultType.Unsuccessful, ResultTypeAddiction.RangeIsNotReachable);
            }
            catch (StarshipCrewIsDeadException)
            {
                return new Results(chosenSpaceship, ResultType.Unsuccessful, ResultTypeAddiction.CrewIsDead);
            }
            catch (StarshipIsDestroyedException)
            {
                return new Results(chosenSpaceship, ResultType.Unsuccessful, ResultTypeAddiction.SpaceshipIsDestroyed);
            }
            catch (StarshipIsOutOfFuelException)
            {
                return new Results(chosenSpaceship, ResultType.Unsuccessful, ResultTypeAddiction.SpaceshipIsOutOfFuelDuringTheRade);
            }
            catch (NoSuitableStarship)
            {
                return new Results(chosenSpaceship, ResultType.RaidIsNotStarted, ResultTypeAddiction.NoSuitableShips);
            }
        }

        return new Results(chosenSpaceship, ResultType.Success, ResultTypeAddiction.Success);
    }

    public void ChangeSpaceships(IReadOnlyCollection<Spaceship.Spaceship> spaceship)
    {
        if (spaceship == null) throw new ArgumentNullException(nameof(spaceship), " cant be null !");
        _spaceshipService = new SpaceshipService(spaceship);
    }

    private static void RaidPreparing(Spaceship.Spaceship spaceship, Route.Route route)
    {
        if (route.Environment.IsWarpRequired && !spaceship.CanJump())
            throw new StarshipDoesNotHaveWarpEngineException();
        if (route.Range > spaceship.MaxReachableRange())
            throw new StarshipCouldNotMakeWarpJumpException();
    }

    private static void CheckSpecialEvents(Spaceship.Spaceship spaceship, SubspaceChannel subspaceChannel)
    {
        if (!subspaceChannel.HasSpecialEvent) return;
        switch (subspaceChannel.SpecialEventType)
        {
            case SpecialEventsType.Flash when !spaceship.HasPhotonDeflector:
                spaceship.CrewIsDead();
                throw new StarshipCrewIsDeadException("Crew is dead !");
            default:
                return;
        }
    }

    private static void HandleColonyDamage(Spaceship.Spaceship spaceship, decimal colonyDamage)
    {
        if (colonyDamage <= 0) return;
        if (spaceship.HasNeutrinoDeflector) return;
        if (!spaceship.IsDeflectorWorking())
            throw new StarshipIsDestroyedException($"Starship is destroyed by the colony");
        spaceship.DeflectorGetsDamage(colonyDamage);
        if (!spaceship.IsSpaceshipWorking())
            throw new StarshipIsDestroyedException($"Starship is destroyed by the colony");
    }

    private static void HandleObstaclesDamage(Spaceship.Spaceship spaceship, decimal clusterDamage)
    {
        if (clusterDamage <= 0) return;
        spaceship.GetDamage(clusterDamage);
        if (!spaceship.IsSpaceshipWorking())
            throw new StarshipIsDestroyedException();
    }

    private static void PassRoute(Spaceship.Spaceship spaceship, Route.Route route)
    {
        if (spaceship.RemainFuel < spaceship.FuelRangeConsumption(route.Range))
            throw new StarshipIsOutOfFuelException();
        CheckSpecialEvents(spaceship, route.Environment.GetSubspaceChannel(0));
        HandleColonyDamage(spaceship, route.GetRouteColonyDamage());
        HandleObstaclesDamage(spaceship, route.Environment.ClusterDamage());
        spaceship.Move(route.Range);
    }
}