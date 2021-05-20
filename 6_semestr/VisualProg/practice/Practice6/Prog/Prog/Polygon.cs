using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog
{
    class Polygon
    {
        public Point[] Points;
        public Point basePoint;

        public Polygon(Point[] _points, Point baseP)
        {
            Points = _points;
            basePoint = baseP;
        }

        public Point[] FixedPoly()
        {
            Point[] poly;
            poly = new Point[Points.Length];

            for (int i = 0; i < Points.Length; i++)
            {
                poly[i].X = Points[i].X;
                poly[i].Y = Points[i].Y;
            }

            for (int i = 0; i < Points.Length; i++)
            {
                poly[i].X += basePoint.X;
                poly[i].Y += basePoint.Y;
            }

            return poly;
        }

        public void Move(int x, int y)
        {
            basePoint = new Point(basePoint.X + x, basePoint.Y + y);
        }
    }
}
