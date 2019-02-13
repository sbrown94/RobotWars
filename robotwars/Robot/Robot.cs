using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public class Point
    {
        public int x;
        public int y;
        public Point(int xx, int yy)
        {
            x = xx;
            y = yy;
        }
    }
    public class Robot
    {
        // The direction the robot is currently facing
        private AbsoluteDirection absoluteDirection;
        private SpinningController spinningController;
        private MovingController movingController;
        private Point position;
        private string myCommands;
        public AbsoluteDirection AbsoluteDirection
        {
            get { return absoluteDirection; }
            set { absoluteDirection = value; }
        }

        // Map input chars to MovementDirection enum
        static Dictionary<char, MovementDirection> _movDict = new Dictionary<char, MovementDirection>
        {
            {'L', MovementDirection.Left},
            {'R', MovementDirection.Right},
            {'M', MovementDirection.Move},
        };

        static Dictionary<char, AbsoluteDirection> _absDict = new Dictionary<char, AbsoluteDirection>
        {
            {'N', AbsoluteDirection.North},
            {'E', AbsoluteDirection.East},
            {'S', AbsoluteDirection.South},
            {'W', AbsoluteDirection.West}
        };

        static Dictionary<AbsoluteDirection, char> _inverseAbsDict = new Dictionary<AbsoluteDirection, char>
        {
            {AbsoluteDirection.North, 'N'},
            {AbsoluteDirection.East, 'E'},
            {AbsoluteDirection.South, 'S'},
            {AbsoluteDirection.West, 'W'}
        };

        public Robot(char absDir, Point initPos, string commands)
        {
            absoluteDirection = _absDict[absDir];
            position = initPos;
            myCommands = commands;
            spinningController = new SpinningController();
            movingController = new MovingController();
        }

        public string RunCommands(Arena arena)
        {
            foreach(char command in myCommands)
            {
                OperateOnCommand(_movDict[command], arena);
            }
            return position.x.ToString() + ' ' + position.y.ToString() + ' ' + _inverseAbsDict[absoluteDirection].ToString();
        }

        // Operate on the provided movement command
        private void OperateOnCommand(MovementDirection movDir, Arena arena)
        {
            absoluteDirection = spinningController.Turn(absoluteDirection, movDir);
            position = movingController.Move(absoluteDirection, movDir, position, arena);
        }
    }
}
