﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public class CommandParser
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
                Console.WriteLine("ERROR: " + error);
                //Console.WriteLine("Press any key to exit...");
                //Console.ReadLine();
            }
            return commands;
        }

        public string ReadFromFile(string path)
        {
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
            var arenaSetup = commands[0].Split(' ');
            if (arenaSetup.Count() != 2) return "Arena setup is invalid.";
            foreach(var coord in arenaSetup)
            {
                var num = -1;
                var ok = Int32.TryParse(coord, out num);
                if (!ok) return "Arena setup size is invalid";
            }
            for(var i = 1; i < commands.Count(); i++)
            {
                if(i % 2 == 1)
                {
                    var line = commands[i].Split(' ');
                    if (line.Count() != 3) return "Invalid starting position for Robot " + ((i / 2) + 0.5);
                    for(var j = 0; j < 3; j++)
                    {
                        if (j < 2)
                        {
                            var num = -1;
                            var ok = Int32.TryParse(line[j], out num);
                            if (!ok) return "Invalid coordinates for Robot " + ((i / 2) + 0.5);
                        }
                        else
                        {
                            var ch = '#';
                            var ok = char.TryParse(line[j], out ch);
                            if (!ok && (ch == 'N' || ch == 'E' || ch == 'W' || ch == 'S'))
                                return "Invalid starting direction for Robot " + ((i / 2) + 0.5);
                        }
                    }
                }
                else
                {
                    var line = commands[i];
                    bool ok = line.All(x => "LMR".Contains(x));
                    if (!ok) return "Invalid characters in instructions for Robot " + ((i / 2));
                }
            }
            return "none";
        }
    }
}
