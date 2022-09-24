using FluentAssertions;
using MarsMission.Exceptions;
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

    [TestCase("sprit1")]
    public void IncorrectRoverNameThrowsException(string name)
    {
        string errorMessage = "Rover landing cancelled:";
        var ex = Assert.Throws<RoverLandingException>(() => _missionControl.LandRoverOnLocation(name, new Position(1, 2), Directions.N));
        Assert.That(ex.Message, Is.EqualTo($"{errorMessage} Rover name does not exist."));
    }

    [TestCase(-1, 6)]
    public void IncorrectRoverPositionThrowsException(int x, int y)
    {
        string errorMessage = "Rover landing cancelled:";
        var ex = Assert.Throws<RoverLandingException>(() => _missionControl.LandRoverOnLocation("spirit", new Position(x, y), Directions.N));
        Assert.That(ex.Message, Is.EqualTo($"{errorMessage} Invalid Co-ordinates."));
    }

    [TestCase(1, 5)]
    public void RoverObstacleFoundShouldThrowException(int x, int y)
    {
        string errorMessage = "Rover landing cancelled:";
        _missionControl.LandRoverOnLocation("opportunity", new Position(x, y), Directions.N);
        var ex = Assert.Throws<RoverLandingException>(() => _missionControl.LandRoverOnLocation("spirit", new Position(1, 5), Directions.N));
        Assert.That(ex.Message, Is.EqualTo($"{errorMessage} Obstacle found."));
    }

    [TestCase(3, 3)]
    public void AlienObstacleFoundShouldThrowException(int x, int y)
    {
        string errorMessage = "Rover landing cancelled:";
        var ex = Assert.Throws<RoverLandingException>(() => _missionControl.LandRoverOnLocation("spirit", new Position(3, 3), Directions.N));
        Assert.That(ex.Message, Is.EqualTo($"{errorMessage} Obstacle found."));
    }

    [Test]
    public void RoverLandedInPlateauSuccessfully()
    {
        _missionControl.LandRoverOnLocation("spirit", new Position(2, 2), Directions.N);
        _missionControl.ChosenPlateau.RoversInPlateau["spirit"].IsLandedOnPlateau.Should().BeTrue();
    }
    [TestCase("spirit")]
    [TestCase("opportunity")]
    //[TestCase("something")]
    //[TestCase("sPirit")]
    //[TestCase("")]
    //[TestCase(null)]
    public void CheckIfRoverNameValid(string name)
    {
        bool result = _missionControl.CheckRoverExists(name);
        Assert.That(result, Is.EqualTo(true));

    }

    [TestCase("MLLRMRMLLRlrm")]
    //[TestCase("LS")]
    //[TestCase("")]
    //[TestCase(null)]
    public void CheckIfMessageIsInCorrectFormat(string message)
    {
        bool result = _missionControl.CheckForMessageValidity(message);
        Assert.That(result, Is.EqualTo(true));
    }
}