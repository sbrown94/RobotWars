using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotWars.Tests
{
    class IntegrationTests
    {
        // To check full integration including File IO, make sure commands.txt is
        // in RobotWars.Tests/bin/Debug/netcoreapp2.1
        [Test]
        public void TestRunFullSimulation()
        {
            // Arrange
            MainController mControl = new MainController();
            List<string> output = new List<string>();
            List<string> expectedOutput = new List<string>();
            expectedOutput.Add("1 3 N");
            expectedOutput.Add("5 1 E");

            // Act
            output = mControl.InitSimulation();

            // Assert
            Assert.AreEqual(output.Count, expectedOutput.Count);
            for (var i = 0; i < output.Count; i++)
            {
                Assert.AreEqual(output[i], expectedOutput[i]);
            }
        }
    }
}
