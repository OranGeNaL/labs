using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchFigures
{
    class Hole
    {
        public Point Pos { get; set; }
        public Point[] Points { get; set; }
        public Color FrameColor { get; set; }
        public int PairInd { get; set; }

        public Hole()
        {

        }

        public Hole(Point _point, Point[] _points, Color _color, int _ind)
        {
            Pos = _point;
            FrameColor = _color;
            PairInd = _ind;
            Points = new Point[_points.Length];
            for (int i = 0; i < _points.Length; i++)
            {
                Points[i].X = _points[i].X;
                Points[i].Y = _points[i].Y;
            }
            FixPoly();
        }

        private void FixPoly()
        {
            for(int i = 0; i < Points.Length; i++)
            {
                Points[i].X += Pos.X;
                Points[i].Y += Pos.Y;
            }
        }

        public Point GetRightBottom()
        {
            Point point = new Point(0, 0);
            foreach(var i in Points)
            {
                if (i.X > point.X)
                    point = new Point(i.X, point.Y);
                if (i.Y > point.Y)
                    point = new Point(point.X, i.Y);
            }
            return point;
        }

        public Point GetLeftTop()
        {
            Point point = new Point(500, 500);
            foreach (var i in Points)
            {
                if (i.X < point.X)
                    point = new Point(i.X, point.Y);
                if (i.Y < point.Y)
                    point = new Point(point.X, i.Y);
            }
            return point;
        }
    }
}
