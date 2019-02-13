using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    class MovingController
    {
        public Point Move(AbsoluteDirection absDir, MovementDirection movDir, Point pos)
        {
            if (movDir == MovementDirection.Move)
            {
                switch (absDir)
                {
                    case AbsoluteDirection.North:
                        pos.y++;
                        break;
                    case AbsoluteDirection.East:
                        pos.x++;
                        break;
                    case AbsoluteDirection.West:
                        pos.x--;
                        break;
                    case AbsoluteDirection.South:
                        pos.y--;
                        break;
                    default:
                        break;
                }
            }
            return pos;
        }
    }
}
