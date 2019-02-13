using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public class MovingController
    {
        public Point Move(AbsoluteDirection absDir, MovementDirection movDir, Point pos, Arena arena)
        {
            if (movDir == MovementDirection.Move)
            {
                Point oldPos = pos;
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
                if(pos.x > arena.size.x ||
                    pos.y > arena.size.y ||
                    pos.x < 0 ||
                    pos.y < 0)
                {
                    // movement is invalid, goes over the edge of the arena
                    // TODO: what happens in this case?
                }
            }
            return pos;
        }
    }
}
