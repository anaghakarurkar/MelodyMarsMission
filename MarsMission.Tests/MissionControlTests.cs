using FluentAssertions;

namespace MarsMission.Tests;

[TestFixture]
public class MissionControlTests
{
    MissionControl missionControl;
    [SetUp]
    public void Setup()
    {
        missionControl = new MissionControl(new Position(5, 5));
    }

    [Test]
    
    public void CheckForMaxGridCoordinates()
    {
        Position maxCoordinates = missionControl.ChosenPlateau.MaxCoordinates;
        maxCoordinates.X.Should().BeInRange(1, 5);
        maxCoordinates.Y.Should().BeInRange(1, 5);
    }
    [Test]
    public void IfGridMaxSizeIsNullSetItToDefaultValue()
    {
        Position maxCoordinates = missionControl.ChosenPlateau.MaxCoordinates;
        maxCoordinates.Equals(null).Should().BeFalse();
    }

    [Test]
    public void RoversInPlateauShouldNotBeNull()
    {
        missionControl.ChosenPlateau.RoversInPlateau.Should().NotBeEmpty();
    }

    [Test]
    public void TestToPlaceRoverOnPosition()
    {
        missionControl.LandRoverOnLocation(new Position(1, 2), Directions.N).Should().Be(true, "co-ordinates should be valid.");
    }
}