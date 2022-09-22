using FluentAssertions;

namespace MarsMission.Tests;

public class Tests
{
    MissionControl missionControl;
    [SetUp]
    public void Setup()
    {
        missionControl = new MissionControl(new Position(15, 5));
    }

    [Test]
    public void CheckForMaxGridCoordinates()
    {
        missionControl.ChosenPlateau.MacCoordinates.X.Should().BeInRange(1, 5);
        missionControl.ChosenPlateau.MacCoordinates.Y.Should().BeInRange(1, 5);
    }
}