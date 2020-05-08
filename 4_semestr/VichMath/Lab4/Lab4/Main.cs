using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    static class Main
    {
        public static string sourcePath;
        public static int numOfCouples = 0;
        public static double[,] couples; // Пары значений couples[*, 0] - x и couples[*, 1] - y
        public static double convertCoef = 1;

        public static List<Dot> dots = new List<Dot>();
        public static List<Line> lines = new List<Line>();
        public static List<Curve> curves = new List<Curve>();

        public static double GetMinX()
        {
            double res = couples[0, 0];
            for(int i = 1; i < numOfCouples; i++)
            {
                if (couples[i, 0] < res)
                    res = couples[i, 0];
            }
            return res;
        }

        public static double GetMaxX()
        {
            double res = couples[0, 0];
            for (int i = 1; i < numOfCouples; i++)
            {
                if (couples[i, 0] > res)
                    res = couples[i, 0];
            }
            return res;
        }

        public static int Factorial(int k)
        {
            if (k == 0)
                return 1;
            else if (k == 1)
                return 1;
            else if (k > 0)
            {
                int result = 1;
                for (int i = 1; i <= k; i++)
                {
                    result *= i;
                }
                return result;
            }
            else
                return 0;
        }
    }

    class Dot
    {
        public int x, y;
        public Dot(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
        public Dot(double _x, double _y)
        {
            _x = _x * Graphic.scale;
            if (_x > 0)
            {
                _x = Math.Abs(_x) + Graphic.SCREEN_HALF;
            }
            else
            {
                _x += Graphic.SCREEN_HALF;
            }
            _y = _y * Graphic.scale;
            if (_y > 0)
            {
                _y = Graphic.SCREEN_HALF - _y;
            }
            else
            {
                _y = Math.Abs(_y) + Graphic.SCREEN_HALF;
            }
            x = (int)_x;
            y = (int)_y;
        }
    }

    class Line
    {
        public Dot firstPoint, secondPoint;
        public Line(Dot _firstPoint, Dot _secondPoint)
        {
            firstPoint = _firstPoint;
            secondPoint = _secondPoint;
        }

        public Line(int _x1, int _y1, int _x2, int _y2)
        {
            firstPoint = new Dot(_x1, _y1);
            secondPoint = new Dot(_x2, _y2);
        }
    }

    class Curve
    {
        public List<Dot> dots = new List<Dot>();
        public Point[] ConvertToPoints()
        {
            Point[] points = new Point[dots.Count];
            for(int i = 0; i < dots.Count; i++)
            {
                points[i] = new Point(dots[i].x, dots[i].y);
            }
            return points;
        }
    }

    static class Graphic
    {
        public static int scale = 100;
        public const int SCREEN_HALF = 250;

        public static void GetDelta()
        {
            double max = 0;
            for(int i = 0; i < Main.numOfCouples; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    if (Math.Abs(Main.couples[i, j]) > max)
                        max = Math.Abs(Main.couples[i, j]);
                }
            }
            max = (int)max + 1;
            max *= 2;

            scale = (int)(500 / max);
        }
        public static void ImportCouples()
        {
            for (int i = 0; i < Main.numOfCouples; i++)
            {
                Main.dots.Add(new Dot(Main.couples[i, 0], Main.couples[i, 1]));
            }
        }
    }
}
