using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public class MainController
    {
        Arena arena;
        List<Robot> robots;
        public List<string> InitSimulation(List<string> commands)
        {
            var arenaCommand = commands[0].Split(' ');
            var arenaSize = new Point(Int32.Parse(arenaCommand[0]), Int32.Parse(arenaCommand[1]));
            arena = new Arena(arenaSize);
            robots = new List<Robot>();

            // iterate over the command list to initialize the robots
            // every two lines is one new robot
            for (int i = 1; i < commands.Count; i += 2)
            {
                var robotInitCommand = commands[i].Split(' ');
                var robotAbsoluteDir = Char.Parse(robotInitCommand[2]);
                var robotStartPos = new Point(Int32.Parse(robotInitCommand[0]), Int32.Parse(robotInitCommand[1]));
                var robotInstructions = commands[i + 1];
                Robot robot = new Robot(robotAbsoluteDir, robotStartPos, robotInstructions);
                robots.Add(robot);
            }
            List<string> outputs = new List<string>();
            outputs = RunSimulation();
            return outputs;
        }

        // execute the commands for each robot in order and return to Main
        public List<string> RunSimulation()
        {
            List<string> outputs = new List<string>();
            foreach (var robot in robots)
            {
                string output = robot.RunCommands(arena);
                outputs.Add(output);
            }
            return outputs;
        }

    }
}
