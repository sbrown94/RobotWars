using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotWars.Tests
{
    class ParserTests
    {
        [TestCase("5 5\r\n4 3 E\r\nMRRRLLR")]
        public void TestInputIsValid(string input)
        {
            var fileParser = new FileParser();
            var data = fileParser.GetCommandsAsStringList(input);
            var isValid = fileParser.Validate(data);
            Assert.IsTrue(isValid);
        }

        [TestCase("5 5\r\n2 2 W\r\nMMRRMMLL\r\n2 4 E", "Each robot must have a starting location and instructions")]
        [TestCase("ABBB B\r\n4 3 E\r\nMRRDEASDLR", "Arena setup size is invalid")]
        [TestCase("", "Not enough data to run simulation")]
        [TestCase("2 3\r\n4 3 N", "Not enough data to run simulation")]
        [TestCase("5 5\r\nWRONG\r\nMMRRMMLL", "Invalid starting position for Robot 1")]
        [TestCase("5 5\r\n7 3 E\r\nMMRRMMLL", "Starting coordinates are outside the range of the arena for Robot 1")]
        [TestCase("5 5\r\n4 3 X\r\nMMRRMMLL", "Invalid starting direction for Robot 1")]
        [TestCase("5 5\r\n4 3 E\r\nMRRDEASDLR", "Invalid characters in instructions for Robot 1")]
        public void TestInputIsInvalid(string input, string expected)
        {
            var fileParser = new FileParser();
            var data = fileParser.GetCommandsAsStringList(input);
            var ex = Assert.Throws<Exception>(() => fileParser.Validate(data));
            Assert.That(ex.Message, Is.EqualTo(expected));
        }

        [TestCase("alksjhd", "Input string was not in a correct format.")]
        public void TestInputFormatIsValid(string input, string expected)
        {
            var fileParser = new FileParser();
            var data = fileParser.GetCommandsAsStringList(input);
            var ex = Assert.Throws<FormatException>(() => fileParser.Validate(data));
            Assert.That(ex.Message, Is.EqualTo(expected));
        }
    }
}
