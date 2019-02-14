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
            // initialize the main controller that will control the simulation
            MainController mControl = new MainController();
            List<string> output = new List<string>();
            output = mControl.InitSimulation();

            // display output and wait for user input to terminate
            Console.WriteLine("Output:");
            foreach(var line in output)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
