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

    [Test]
    public void CheckForAnyLandingProblems()
    {
        string roverName = "spirit";
        string errorMessage = "Rover landing cancelled:";
        var ex = Assert.Throws<RoverLandingException>(() => _missionControl.LandRoverOnLocation(roverName, new Position(1, 2), Directions.N));
        Assert.That(ex.Message, Is.AnyOf($"{errorMessage} Invalid Co-ordinates."), $"{errorMessage} Rover name does not exist.", $"{errorMessage} Obstacle found.");
    }
    

    [TestCase("spirit")]
    [TestCase("opportunity")]
    //[TestCase("something")]
    //[TestCase("sPirit")]
    //[TestCase("")]
    //[TestCase(null)]
    public void CheckIfRoverNameValid(string name)
    {
       bool result =  _missionControl.CheckRoverExists(name);
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