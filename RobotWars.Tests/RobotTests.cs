using NUnit.Framework;
using RobotWars;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("alksjhd", "Not enough data to run simulation.")]
        [TestCase("5 5\r\n9 3 E\r\nMRRRLLR", "none")]
        [TestCase("5 5\r\n9 3 E\r\nMRRDEASDLR", "Invalid characters in instructions for Robot 1")]
        public void TestInputIsValid(string input, string expected)
        {
            var commandParser = new CommandParser();
            var data = commandParser.GetCommands(input);
            var isValid = commandParser.Validate(data);
            Assert.AreEqual(isValid, expected);
        }

        [TestCase(AbsoluteDirection.East, MovementDirection.Left, AbsoluteDirection.North)]
        [TestCase(AbsoluteDirection.North, MovementDirection.Move, AbsoluteDirection.North)]
        [TestCase(AbsoluteDirection.South, MovementDirection.Right, AbsoluteDirection.West)]
        public void TestSpinningController(AbsoluteDirection startAbsoluteDirection, MovementDirection directionToTurn, AbsoluteDirection finalDirection)
        {
            SpinningController spinningController = new SpinningController();
            var result = spinningController.Turn(startAbsoluteDirection, directionToTurn);
            Assert.AreEqual(result, finalDirection);
        }

        //[TestCase("5 5\r\n1 2 N\r\nLMLMLMLMM", "1 3 N")]
        //public void TestCompleteSimulation(string commands, string expected)
        //{
        //    MainController mControl = new MainController();
        //    mControl.InitSimulation(commands);
        //}

        [TestCase(5, 5, 1, 2, 'N', "LMLMLMLMM", "1 3 N")]
        public void TestRobot(int arenaX, int arenaY, int robotX, int robotY, char startFacing, string commands, string expected)
        {
            Robot robot = new Robot(startFacing, new Point(robotX, robotY), commands);
            Arena arena = new Arena(new Point(arenaX, arenaY));
            var result = robot.RunCommands(arena);
            Assert.AreEqual(result, expected);
        }
    }
}