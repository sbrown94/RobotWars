using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotWars.Tests
{
    class ParserTests
    {
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
    }
}
