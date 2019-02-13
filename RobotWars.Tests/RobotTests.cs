using NUnit.Framework;
using RobotWars;
using System.Collections.Generic;

namespace RobotWars.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
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

        [TestCase(9, 9, AbsoluteDirection.North, MovementDirection.Move, 5, 5, 5, 6)]
        [TestCase(6, 4, AbsoluteDirection.West, MovementDirection.Left, 4, 2, 4, 2)]
        [TestCase(8, 6, AbsoluteDirection.East, MovementDirection.Move, 8, 9, 9, 9)]
        public void TestMovingController(int arenaSizeX, int arenaSizeY, AbsoluteDirection absDir, MovementDirection movDir, int robotX, int robotY, int expectX, int expectY)
        {
            MovingController movingController = new MovingController();
            Arena arena = new Arena(new Point(arenaSizeX, arenaSizeY));
            Point result = movingController.Move(absDir, movDir, new Point(robotX, robotY), arena);
            Point expected = new Point(expectX, expectY);
            Assert.AreEqual(result.x, expected.x);
            Assert.AreEqual(result.y, expected.y);
        }

        [TestCase(5, 5, 1, 2, 'N', "LMLMLMLMM", "1 3 N")]
        [TestCase(5, 5, 3, 3, 'E', "MMRMMRMRRM", "5 1 E")]
        public void TestRobot(int arenaX, int arenaY, int robotX, int robotY, char startFacing, string commands, string expected)
        {
            Robot robot = new Robot(startFacing, new Point(robotX, robotY), commands);
            Arena arena = new Arena(new Point(arenaX, arenaY));
            string result = robot.RunCommands(arena);
            Assert.AreEqual(result, expected);
        }
    }
}