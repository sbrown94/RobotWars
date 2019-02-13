using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public class Program
    {
        static void Main(string[] args)
        {
            CommandParser parser = new CommandParser();
            var commands = parser.GetCommandsFromFile("commands.txt");
            MainController mControl = new MainController();
            List<string> output = new List<string>();
            output = mControl.InitSimulation(commands);
            foreach(var line in output)
            {
                Console.WriteLine(line);
            }
            Console.ReadLine();
        }
    }
}
