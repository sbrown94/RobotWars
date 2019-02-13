using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public class SpinningController
    {
        public AbsoluteDirection Turn(AbsoluteDirection absDir, MovementDirection movDir)
        {
            var noDirections = Enum.GetNames(typeof(AbsoluteDirection)).Length;
            switch (movDir)
            {
                case MovementDirection.Right:
                    absDir++;
                    if((int)absDir > noDirections)
                    {
                        absDir -= noDirections;
                    }
                    break;
                case MovementDirection.Left:
                    absDir--;
                    if ((int)absDir < 0)
                    {
                        absDir += noDirections;
                    }
                    break;
                default:
                    // do not rotate
                    break;
            }
            return absDir;
        }
    }
}
