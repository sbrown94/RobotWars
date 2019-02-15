using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotWars.Tests
{
    class ArenaSetTests
    {
        private Arena mockArena;

        [SetUp]
        public void Setup()
        {
            mockArena = new Arena(new Point(5, 5));
        }

        [TestCase(5, 5)]
        [TestCase(4, 2)]
        public void TestSetPositionOccupiedSuccess(int robotX, int robotY)
        {
            mockArena.SetPositionOccupied(new Point(robotX, robotY));
            Assert.IsNotEmpty(mockArena.GetAllOccupiedPoints());
            Assert.AreEqual(robotX, mockArena.GetAllOccupiedPoints()[0].x);
            Assert.AreEqual(robotY, mockArena.GetAllOccupiedPoints()[0].y);
        }

        [TestCase(9, 5, "Attempted to set a position outside of the arena")]
        [TestCase(8, 8, "Attempted to set a position outside of the arena")]
        [TestCase(2, 6, "Attempted to set a position outside of the arena")]
        public void TestSetPositionoccupiedFail(int robotX, int robotY, string exception)
        {
            var ex = Assert.Throws<Exception>(() => mockArena.SetPositionOccupied(new Point(robotX, robotY)));
            Assert.That(ex.Message, Is.EqualTo(exception));
        }
    }

    class ArenaCheckTests
    {
        private Arena mockArena;

        [SetUp]
        public void Setup()
        {
            mockArena = new Arena(new Point(5, 5));
            mockArena.SetPositionOccupied(new Point(3, 3));
            mockArena.SetPositionOccupied(new Point(3, 4));
        }

        [TestCase(4, 3, true)]
        [TestCase(5, 4, true)]
        [TestCase(4, 5, true)]
        [TestCase(6, 5, false)]
        [TestCase(6, 6, false)]
        [TestCase(5, 6, false)]
        public void TestCheckPositionContained(int robotX, int robotY, bool contained)
        {
            Assert.AreEqual(mockArena.CheckPositionIsContained(new Point(robotX, robotY)), contained);
        }

        [TestCase(3, 3, true)]
        [TestCase(4, 3, false)]
        public void TestCheckPositionOccupied(int robotX, int robotY, bool exists)
        {
            Assert.AreEqual(mockArena.CheckPositionIsOccupied(new Point(robotX, robotY)), exists);
        }
    }
}
