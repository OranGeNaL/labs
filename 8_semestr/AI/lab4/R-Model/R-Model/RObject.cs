using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace R_Model
{
    class RObject
    {
        public Point Position { get; set; }
        public int Type { get; set; }

        public RObject(Point _position)
        {
            Position = _position;
        }

        public RObject(Point _position, int _type)
        {
            Position = _position;
            Type = _type;
        }
    }

    static class MathDealer
    {
        public static Point GetAriphmeticAveragePoint(List<RObject> rObjects)
        {
            Point res = new Point(0, 0);

            if (rObjects.Count == 0)
                return res;

            foreach (var i in rObjects)
            {
                res.X += i.Position.X;
                res.Y += i.Position.Y;
            }

            res.X = res.X / rObjects.Count;
            res.Y = res.Y / rObjects.Count;

            return res;
        }

        public static Point GetPerpendicularLinePoint(Point point, float k, int x)
        {
            Point res = new Point();

            res.X = x;
            res.Y = (int)((-1 / (float)k) * (x - point.X) + point.Y);

            return res;
        }

        public static Point GetPerpendPoint(Point point1, Point point2)
        {
            Point res = new Point();

            res = new Point((point1.X + point2.X) / 2, (point1.Y + point2.Y) / 2);

            return res;
        }

        public static Point GetPerpendPoint(Point point1, Point point2, double lambda)
        {
            Point res = new Point();

            double x = (point1.X + lambda * point2.X) / (1 + lambda);
            double y = (point1.Y + lambda * point2.Y) / (1 + lambda);

            res = new Point((int)x, (int)y);

            return res;
        }

        public static double GetAverageDistance(List<RObject> objects)
        {
            Point averagePoint = GetAriphmeticAveragePoint(objects);
            double res = 0;

            foreach(var i in objects)
            {
                res += Math.Sqrt(Math.Pow(averagePoint.X - i.Position.X, 2) + Math.Pow(averagePoint.Y - i.Position.Y, 2));
            }

            res /= objects.Count;
            

            return res;
        }
    }
}
