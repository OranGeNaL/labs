using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchFigures
{
    class Figure
    {
        public Point Pos { get; set; }
        public Point[] Points { get; set; }
        public Color FillColor { get; set; }
        public int PairInd { get; set; }

        public Figure()
        {

        }

        public Figure(Point _point, Point[] _points, Color _color, int _ind)
        {
            Pos = _point;
            FillColor = _color;
            PairInd = _ind;
            Points = new Point[_points.Length];
            for(int i = 0; i < _points.Length; i++)
            {
                Points[i].X = _points[i].X;
                Points[i].Y = _points[i].Y;
            }
        }

        public void SetPos(int _x, int _y)
        {
            Pos = new Point(_x, _y);
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
                poly[i].X += Pos.X;
                poly[i].Y += Pos.Y;
            }

            return poly;
        }


        public Point GetRightBottom()
        {
            Point point = new Point(0, 0);
            foreach (var i in FixedPoly())
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
            foreach (var i in FixedPoly())
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
