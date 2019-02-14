using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public class FileParser
    {
        public List<string> GetCommandsFromFile(string path)
        {
            var fileData = ReadFromFile(path);
            var commands = GetCommands(fileData);
            return commands;
        }
        public List<string> GetCommands(string rawCommands)
        {
            var commands = GetCommandsAsStringList(rawCommands);
            string error = Validate(commands);
            if (error != "none")
            {
                throw new Exception(error);
            }
            return commands;
        }

        public string ReadFromFile(string path)
        {
            if(!System.IO.File.Exists(path))
            {
                throw new Exception("commands.txt does not exist");
            }
            var contents = System.IO.File.ReadAllText(path);
            return contents;
        }

        public List<string> GetCommandsAsStringList(string input)
        {
            var commands = input.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            var commandStack = new List<string>();
            foreach (var line in commands)
            {
                commandStack.Add(line);
            }
            return commandStack;
        }

        // Validate that the input text file is in the correct format to run the simulation
        public string Validate(List<string> commands)
        {
            if (commands.Count() == 0) return "Command list is empty.";
            if (commands.Count() < 3) return "Not enough data to run simulation.";
            if (commands.Count() % 2 != 1) return "Each robot must have a starting location and instructions.";
            var arenaSetup = commands[0].Split(' ');
            if (arenaSetup.Count() != 2) return "Arena setup is invalid.";
            foreach(var coord in arenaSetup)
            {
                var num = -1;
                var ok = Int32.TryParse(coord, out num);
                if (!ok) return "Arena setup size is invalid";
            }
            Point arenaSetupCoords = new Point(Int32.Parse(arenaSetup[0]), Int32.Parse(arenaSetup[1]));
            for (var i = 1; i < commands.Count(); i++)
            {
                if(i % 2 == 1)
                {
                    var robotNo = (((float)i / 2) + 0.5f);
                    var line = commands[i].Split(' ');
                    if (line.Count() != 3) return "Invalid starting position for Robot " + robotNo;
                    for(var j = 0; j < 3; j++)
                    {
                        if (j < 2)
                        {
                            var num = -1;
                            var ok = Int32.TryParse(line[j], out num);
                            if (!ok) return "Invalid coordinates for Robot " + robotNo;
                            var xOrY = j == 0 ? arenaSetupCoords.x : arenaSetupCoords.y;
                            if (num < 0 || num > xOrY) return "Starting coordinates are outside the range of the arena for Robot " + robotNo;
                        }
                        else
                        {
                            var ch = '#';
                            var ok = char.TryParse(line[j], out ch);
                            if (!ok && (ch == 'N' || ch == 'E' || ch == 'W' || ch == 'S'))
                                return "Invalid starting direction for Robot " + robotNo;
                        }
                    }
                }
                else
                {
                    var robotNo = ((i / 2));
                    var line = commands[i];
                    bool ok = line.All(x => "LMR".Contains(x));
                    if (!ok) return "Invalid characters in instructions for Robot " + robotNo;
                }
            }
            return "none";
        }
    }
}
