using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Deflector.DeflectorModels;
using Itmo.ObjectOrientedProgramming.Lab1.Deflector.DeflectorModels.DeflectorModifications;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentsModels;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentsModels.NebulaModels;
using Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions.VariableExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Raid;
using Itmo.ObjectOrientedProgramming.Lab1.Raid.RaidResults;
using Itmo.ObjectOrientedProgramming.Lab1.Raid.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipModels;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class MainTests
{
    public static IEnumerable<object[]> BaseAvgureShuttleTestData()
    {
        yield return new object[]
        {
            new Avgure(),
            new Shuttle(),
            new BaseRoute(new IncreasedDensityNebula(500, 50, 50, 50, false)),
        };
    }

    public static IEnumerable<object[]> VacklasDefaultAndWithPhotonDeflectorTestData()
    {
        yield return new object[]
        {
            new Vacklas(),
            new Vacklas(),
            new BaseRoute(new IncreasedDensityNebula(1, 0, 0, 0, true)),
        };
    }

    public static IEnumerable<object[]> VacklasAvgureMeridianEncounterWithSpaceWhalesTestData()
    {
        yield return new object[]
        {
            new Vacklas(),
            new Avgure(),
            new Meridiana(),
            new BaseRoute(new NeutrinoNebula(1, 30, 0, 0, false)),
        };
    }

    public static IEnumerable<object[]> VacklasAndShuttleFourthTestData()
    {
        yield return new object[]
        {
            new Vacklas(),
            new Shuttle(),
            new BaseRoute(new Space(30, 0, 0, false)),
        };
    }

    public static IEnumerable<object[]> AvgureStellaIncreasedDensityNebulaFifthTestData()
    {
        yield return new object[]
        {
            new Avgure(),
            new Stella(),
            new BaseRoute(new IncreasedDensityNebula(100, 0, 0, 0, false)),
        };
    }

    public static IEnumerable<object[]> VacklasShuttleSixTestData()
    {
        yield return new object[]
        {
            new Vacklas(),
            new Shuttle(),
            new BaseRoute(new IncreasedDensityNebula(40, 0, 0, 0, false)),
        };
    }

    public static IEnumerable<object[]> RaidWithSomeRoutesTestData()
    {
        yield return new object[]
        {
            new Stella(),
            new Avgure(),
            new BaseRoute(new IncreasedDensityNebula(100, 0, 5, 0, true)),
            new BaseRoute(new Space(50, 3, 1, false)),
            new BaseRoute(new NeutrinoNebula(40, 5, 0, 0, false)),
        };
    }

    [Theory]
    [MemberData(nameof(BaseAvgureShuttleTestData))]
    public void MoveSpaceshipShouldReturnStarshipIsDestroyedException(
        Avgure avgure,
        Shuttle shuttle,
        Route route)
    {
        if (avgure == null || shuttle == null || route == null)
            throw new ArgumentIsNullException("Some arguments for the test are null ! ");

        shuttle.Refuel(100);
        avgure.Refuel(100);

        // Arrange
        var raidService = new RaidService(new List<Spaceship.Spaceship> { avgure }, new List<Route> { route });

        // Act
        Results avgureResult = raidService.StartRaid();

        raidService.ChangeSpaceships(new List<Spaceship.Spaceship> { shuttle });
        Results shuttleResult = raidService.StartRaid();

        // Assert
        Assert.Equal(ResultTypeAddiction.NoSuitableShips, shuttleResult.Details);
        Assert.Equal(ResultTypeAddiction.RangeIsNotReachable, avgureResult.Details);
    }

    [Theory]
    [MemberData(nameof(VacklasDefaultAndWithPhotonDeflectorTestData))]
    public void SpaceshipGotFlashEventOneGotSuccessOneGotDeadCrewException(
        Vacklas vacklasDefault,
        Vacklas vacklasNeutrino,
        Route route)
    {
        // Arrange
        if (vacklasDefault == null) throw new ArgumentNullException(nameof(vacklasDefault));
        if (vacklasNeutrino == null) throw new ArgumentNullException(nameof(vacklasNeutrino));
        if (route == null) throw new ArgumentNullException(nameof(route));
        var raidService = new RaidService(new List<Route> { route });

        // Act
        vacklasNeutrino.Refuel(100);
        vacklasDefault.Refuel(100);
        vacklasNeutrino.ChangeDeflector(new PhotonDeflector(new DeflectorClassA()));

        raidService.ChangeSpaceships(new List<Spaceship.Spaceship> { vacklasDefault });
        Results vacklasDefaultResult = raidService.StartRaid();

        raidService.ChangeSpaceships(new List<Spaceship.Spaceship> { vacklasNeutrino });
        Results vacklasNeutrinoResult = raidService.StartRaid();

        // Assert
        Assert.Equal(ResultTypeAddiction.CrewIsDead, vacklasDefaultResult.Details);
        Assert.Equal(ResultType.Success, vacklasNeutrinoResult.ResultType);
    }

    [Theory]
    [MemberData(nameof(VacklasAvgureMeridianEncounterWithSpaceWhalesTestData))]
    public void VacklasAvgureMeridianaGetSpaceWhaleEncounterExceptVacklasDestroyedAvgureLostDeflectorMeridianaNoDamage(
        Vacklas vacklas,
        Avgure avgure,
        Meridiana meridiana,
        Route route)
    {
        if (vacklas == null) throw new ArgumentNullException(nameof(vacklas));
        if (avgure == null) throw new ArgumentNullException(nameof(avgure));
        if (meridiana == null) throw new ArgumentNullException(nameof(meridiana));
        if (route == null) throw new ArgumentNullException(nameof(route));

        // Arrange
        var raidService = new RaidService(new List<Route> { route });

        // Act
        vacklas.Refuel(1000);
        avgure.Refuel(1000);
        meridiana.Refuel(1000);

        raidService.ChangeSpaceships(new List<Spaceship.Spaceship> { vacklas });
        Results vacklasResult = raidService.StartRaid();

        raidService.ChangeSpaceships(new List<Spaceship.Spaceship> { avgure });
        Results avgureResult = raidService.StartRaid();

        raidService.ChangeSpaceships(new List<Spaceship.Spaceship> { meridiana });
        Results meridianaResult = raidService.StartRaid();

        // Assert
        Assert.Equal(ResultTypeAddiction.SpaceshipIsDestroyed, vacklasResult.Details);
        Assert.False(avgureResult.Spaceship?.IsDeflectorWorking());
        Assert.Equal(ResultType.Success, meridianaResult.ResultType);
    }

    [Theory]
    [MemberData(nameof(VacklasAndShuttleFourthTestData))]
    public void VacklasAndShuttlePassThrowSpaceGetBestShipShuttle(
        Vacklas vacklas,
        Shuttle shuttle,
        Route route)
    {
        // Arrange
        if (vacklas == null) throw new ArgumentNullException(nameof(vacklas));
        if (shuttle == null) throw new ArgumentNullException(nameof(shuttle));
        if (route == null) throw new ArgumentNullException(nameof(route));

        var raidService = new RaidService(new List<Route> { route });

        // Act
        vacklas.Refuel(100);
        shuttle.Refuel(100);
        raidService.ChangeSpaceships(new List<Spaceship.Spaceship> { vacklas, shuttle });
        Results raidResult = raidService.StartRaid();

        // Assert
        Assert.Equal(typeof(Vacklas), raidResult.Spaceship?.GetType());
    }

    [Theory]
    [MemberData(nameof(AvgureStellaIncreasedDensityNebulaFifthTestData))]
    public void AvgureStellaIncreasedDensityNebulaFifthTest(
        Avgure avgure,
        Stella stella,
        Route route)
    {
        // Arrange
        if (avgure == null) throw new ArgumentNullException(nameof(avgure));
        if (stella == null) throw new ArgumentNullException(nameof(stella));
        if (route == null) throw new ArgumentNullException(nameof(route));
        var raidService = new RaidService(new List<Route> { route });

        // Act
        avgure.Refuel(1000);
        stella.Refuel(1000);
        raidService.ChangeSpaceships(new List<Spaceship.Spaceship> { avgure, stella });
        Results raidResult = raidService.StartRaid();

        // Assert
        Assert.Equal(typeof(Stella), raidResult.Spaceship?.GetType());
    }

    [Theory]
    [MemberData(nameof(VacklasShuttleSixTestData))]
    public void VacklasShuttlePassThrowIncreasedDensityNebula(
        Vacklas vacklas,
        Shuttle shuttle,
        Route route)
    {
        // Arrange
        if (vacklas == null) throw new ArgumentNullException(nameof(vacklas));
        if (shuttle == null) throw new ArgumentNullException(nameof(shuttle));
        if (route == null) throw new ArgumentNullException(nameof(route));
        var raidService = new RaidService(new List<Route> { route });
        raidService.ChangeSpaceships(new List<Spaceship.Spaceship> { vacklas, shuttle });

        // Act
        vacklas.Refuel(1000);
        shuttle.Refuel(1000);
        Results raidResult = raidService.StartRaid();

        // Assert
        Assert.Equal(typeof(Vacklas), raidResult.Spaceship?.GetType());
    }

    [Theory]
    [MemberData(nameof(RaidWithSomeRoutesTestData))]
    public void RaidWithSomeRandomRoutesTest(
        Stella stella,
        Avgure avgure,
        Route route1,
        Route route2,
        Route route3)
    {
        // Arrange
        if (stella == null) throw new ArgumentNullException(nameof(stella));
        if (avgure == null) throw new ArgumentNullException(nameof(avgure));
        if (route1 == null) throw new ArgumentNullException(nameof(route1));
        if (route2 == null) throw new ArgumentNullException(nameof(route2));
        if (route3 == null) throw new ArgumentNullException(nameof(route3));
        var raidService = new RaidService(new List<Route> { route1, route2, route3 });

        // Act
        stella.Refuel(1000);
        raidService.ChangeSpaceships(new List<Spaceship.Spaceship> { stella });
        Results stellaResults = raidService.StartRaid();

        avgure.Refuel(500);
        avgure.ChangeDeflector(new PhotonDeflector(new DeflectorClassC()));
        raidService.ChangeSpaceships(new List<Spaceship.Spaceship> { avgure });
        Results avgureResults = raidService.StartRaid();

        // Assert
        Assert.Equal(ResultTypeAddiction.CrewIsDead, stellaResults.Details);
        Assert.Equal(ResultType.Success, avgureResults.ResultType);
    }
}
