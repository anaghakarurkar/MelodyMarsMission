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
        var ex = Assert.Throws<RoverLandingException>(() => _missionControl.LandRoverOnLocation("spirit", new Position(4, 4), Focus.N));
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
    [TestCase("sPirit")]
    [Description("Rover name should be valid")]
    public void Check_If_Rover_Name_Valid(string name)
    {
        bool result = _missionControl.CheckRoverExists(name);
        Assert.That(result, Is.EqualTo(true));
    }

    [TestCase("")]
    [TestCase(null)]
    [TestCase("something")]
    [Description("Test to check if rover name is invalid")]
    public void Should_Return_false_If_Rover_Name_Invalid(string name)
    {
        bool result = _missionControl.CheckRoverExists(name);
        Assert.That(result, Is.EqualTo(false));
    }



    [TestCase("MLLRMRMLLRlrm")]
    [Description("Message should be in correct format")]
    public void Check_If_Message_Is_In_Correct_Format(string message)
    {
        bool result = MissionControl.CheckForMessageValidity(message);
        Assert.That(result, Is.EqualTo(true));
    }

    [TestCase("")]
    [TestCase(null)]
    [TestCase("LS")]
    [Description("Test to check if message is in incorrect format")]
    public void Should_Return_False_If_Messae_Is_In_Incorrect_Format(string message)
    {
        bool result = MissionControl.CheckForMessageValidity(message);
        Assert.That(result, Is.EqualTo(false));
    }




    [TestCase("spirit", "LMLMLMLMM", 1, 2, Focus.N, "1 3 N")]
    [TestCase("opportunity", "MMRMMRMRRM", 3, 3, Focus.E, "5 1 E")]
    [Description("Check if rover returns correct final position and direction")]
    public void Rover_Should_Return_Correct_Destination_String(string roverName, string message, int x, int y, Focus focus, string finalPath)
    {
        _missionControl.LandRoverOnLocation(roverName, new Position(x, y), focus);
        _missionControl.ChosenPlateau.RoversInPlateau[roverName].IsLandedOnPlateau.Should().BeTrue();
        string result = _missionControl.SendMessageToRover(roverName, message);
        result.Should().Be(finalPath);
    }


    [TestCase(2, 2, Focus.W, "MMM", "0 2 W")]
    [TestCase(2, 2, Focus.W, "MMMRMRM", "1 3 E")]
    [TestCase(0, 3, Focus.W, "MMRM", "0 4 N")]
    [TestCase(5, 5, Focus.S, "MMLM", "5 3 E")]
    [Description("Rover should not go out of plateau grid")]
    public void Rover_On_Plateau_Border_Should_Not_Move_Out(int x, int y, Focus focus, string instructions, string expectedOutput)
    {
        string roverName = "spirit";
        _missionControl.LandRoverOnLocation(roverName, new Position(x, y), focus);
        _missionControl.ChosenPlateau.RoversInPlateau[roverName].IsLandedOnPlateau.Should().BeTrue();
        string result = _missionControl.SendMessageToRover(roverName, instructions);
        result.Should().Be(expectedOutput);
    }

    [TestCase(3, 4, Focus.E, "MM", "3 4 E")]
    [Description("Rover should not move if obstacle found")]
    public void Rover_Should_Not_Move_If_Obstacle_Found_While_Moving(int x, int y, Focus focus, string instructions, string expectedOutput)
    {
        string roverName = "spirit";
        _missionControl.LandRoverOnLocation(roverName, new Position(x, y), focus);
        _missionControl.ChosenPlateau.RoversInPlateau[roverName].IsLandedOnPlateau.Should().BeTrue();
        string result = _missionControl.SendMessageToRover(roverName, instructions);
        result.Should().Be(expectedOutput);
    }


    [TearDown]
    public void CleanUp()
    {
        // free resources allocated by test
    }


}