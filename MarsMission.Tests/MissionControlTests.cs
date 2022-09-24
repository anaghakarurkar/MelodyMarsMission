using FluentAssertions;

namespace MarsMission.Tests;

[TestFixture]
public class MissionControlTests
{
    private MissionControl _missionControl;
    [SetUp]
    public void Setup()
    {
        _missionControl = new MissionControl(new Position(5, 5));
    }

    [Test]

    public void CheckForMaxGridCoordinates()
    {
        Position maxCoordinates = _missionControl.ChosenPlateau.MaxCoordinates;
        maxCoordinates.X.Should().BeInRange(1, 5);
        maxCoordinates.Y.Should().BeInRange(1, 5);
    }
    [Test]
    public void IfGridMaxSizeIsNullSetItToDefaultValue()
    {
        Position maxCoordinates = _missionControl.ChosenPlateau.MaxCoordinates;
        maxCoordinates.Equals(null).Should().BeFalse();
    }

    [Test]
    public void RoversInPlateauShouldNotBeNull()
    {
        _missionControl.ChosenPlateau.RoversInPlateau.Should().NotBeEmpty();
    }

    [Test]
    public void TestToPlaceRoverOnPosition()
    {
        bool actualResult = _missionControl.LandRoverOnLocation("spirit", new Position(1, 2), Directions.N);
        Assert.That(actualResult, Is.EqualTo(true), "co-ordinates should be valid.");
       // _missionControl.ChosenPlateau.ObstaclesList
        
    }
}