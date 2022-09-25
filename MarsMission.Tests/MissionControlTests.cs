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

    public void Check_For_Max_Grid_Coordinates()
    {
        Position maxCoordinates = _missionControl.ChosenPlateau.MaxCoordinates;
        maxCoordinates.X.Should().BeInRange(1, 5);
        maxCoordinates.Y.Should().BeInRange(1, 5);
    }
    [Test]
    public void If_Grid_Max_Size_Is_Null_Set_It_To_Default_Value()
    {
        Position maxCoordinates = _missionControl.ChosenPlateau.MaxCoordinates;
        maxCoordinates.Equals(null).Should().BeFalse();
    }

    [Test]
    public void Rovers_In_Plateau_Should_Not_Be_Null()
    {
        _missionControl.ChosenPlateau.RoversInPlateau.Should().NotBeEmpty();
    }

    [TestCase("sprit1")]
    public void Incorrect_Rover_Name_Throws_Exception(string name)
    {
        string errorMessage = "Rover landing cancelled:";
        var ex = Assert.Throws<RoverLandingException>(() => _missionControl.LandRoverOnLocation(name, new Position(1, 2), Focus.N));
        Assert.That(ex.Message, Is.EqualTo($"{errorMessage} Rover name does not exist."));
    }

    [Test]
    public void Incorrect_Rover_Position_Throws_Exception()
    {
        string errorMessage = "Rover landing cancelled:";
        var ex = Assert.Throws<RoverLandingException>(() => _missionControl.LandRoverOnLocation("spirit", new Position(-1, -6), Focus.N));
        Assert.That(ex.Message, Is.EqualTo($"{errorMessage} Invalid Co-ordinates."));
    }

    [TestCase(1, 5)]
    public void Rover_Obstacle_Found_Should_Throw_Exception(int x, int y)
    {
        string errorMessage = "Rover landing cancelled:";
        _missionControl.LandRoverOnLocation("opportunity", new Position(x, y), Focus.N);
        var ex = Assert.Throws<RoverLandingException>(() => _missionControl.LandRoverOnLocation("spirit", new Position(x, y), Focus.N));
        Assert.That(ex.Message, Is.EqualTo($"{errorMessage} Obstacle found."));
    }

    [Test]
    public void Alien_Obstacle_Found_Should_Throw_Exception()
    {
        string errorMessage = "Rover landing cancelled:";
        var ex = Assert.Throws<RoverLandingException>(() => _missionControl.LandRoverOnLocation("spirit", new Position(1, 1), Focus.N));
        Assert.That(ex.Message, Is.EqualTo($"{errorMessage} Obstacle found."));
    }

    [Test]
    public void Rover_Landed_In_Plateau_Successfully()
    {
        _missionControl.LandRoverOnLocation("spirit", new Position(2, 2), Focus.N);
        _missionControl.ChosenPlateau.RoversInPlateau["spirit"].IsLandedOnPlateau.Should().BeTrue();
    }
    [TestCase("spirit")]
    [TestCase("opportunity")]
    //[TestCase("something")]
    //[TestCase("sPirit")]
    //[TestCase("")]
    //[TestCase(null)]
    public void Check_If_Rover_Name_Valid(string name)
    {
        bool result = _missionControl.CheckRoverExists(name);
        Assert.That(result, Is.EqualTo(true));

    }

    [TestCase("MLLRMRMLLRlrm")]
    //[TestCase("LS")]
    //[TestCase("")]
    //[TestCase(null)]
    public void Check_If_Message_Is_In_Correct_Format(string message)
    {
        bool result = MissionControl.CheckForMessageValidity(message);
        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void Rover_1_Should_Return_Correct_Destination_String()
    {
        string roverName = "spirit";
        _missionControl = new(new Position(5, 5));
        _missionControl.LandRoverOnLocation(roverName, new Position(1, 2), Focus.N);
        _missionControl.ChosenPlateau.RoversInPlateau[roverName].IsLandedOnPlateau.Should().BeTrue();
        string result = _missionControl.SendMessageToRover(roverName, "LMLMLMLMM");
        result.Should().Be("1 3 N");
    }

    [Test]
    public void Rover_2_Should_Return_Correct_Destination_String()
    {
        string roverName = "opportunity";
        _missionControl = new(new Position(5, 5));
        _missionControl.LandRoverOnLocation(roverName, new Position(3, 3), Focus.E);
        _missionControl.ChosenPlateau.RoversInPlateau[roverName].IsLandedOnPlateau.Should().BeTrue();
        string result = _missionControl.SendMessageToRover(roverName, "MMRMMRMRRM");
        result.Should().Be("5 1 E");
    }

    [TestCase(2, 2, Focus.W, "MMM", "0 2 W")]
    [TestCase(2, 2, Focus.W, "MMMRMRM", "1 3 E")]
    [TestCase(0, 3, Focus.W, "MMRM", "0 4 N")]
    [TestCase(5, 5, Focus.S, "MMLM", "5 3 E")]
    public void Rover_On_Plateau_Border_Should_Not_Move_Out(int x, int y, Focus focus, string instructions, string expectedOutput)
    {
        string roverName = "spirit";
        _missionControl = new(new Position(5, 5));
        _missionControl.LandRoverOnLocation(roverName, new Position(x, y), focus);
        _missionControl.ChosenPlateau.RoversInPlateau[roverName].IsLandedOnPlateau.Should().BeTrue();
        string result = _missionControl.SendMessageToRover(roverName, instructions);
        Console.WriteLine(result);
        result.Should().Be(expectedOutput);
    }
}