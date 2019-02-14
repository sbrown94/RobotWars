using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public class Arena
    {
        public Point size;
        List<Point> occupiedPoints;
        public Arena(Point s)
        {
            size = s;
            occupiedPoints = new List<Point>();
        }

        public bool CheckPositionIsContained(Point pos)
        {
            if (pos.x > size.x ||
                pos.y > size.y ||
                pos.x < 0 ||
                pos.y < 0)
            {
                return false;
            }
            return true;
        }

        public bool CheckPositionIsOccupied(Point pos)
        {
            if (occupiedPoints.Any(point => point.x == pos.x && point.y == pos.y))
            {
                return true;
            }
            return false;
        }

        public void SetPositionOccupied(Point pos)
        {
            if (!CheckPositionIsContained(pos)) throw new Exception("Attempted to set a position outside of the arena");
            if (CheckPositionIsOccupied(pos)) throw new Exception("A robot already exists at position " + pos.x + "," + pos.y);
            occupiedPoints.Add(pos);
        }

        public List<Point> GetAllOccupiedPoints()
        {
            return occupiedPoints;
        }
    }
}
