using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafBuilder
{
    public static class Main
    {

        public static int dotCount = 0;
        public static int dotMax = 10;
        public static int lineCount = 0;
        public static int activeDotInd = 0;
        public static int mouseX;
        public static int mouseY;
        public static string sourcePath = "";
        public static string destPath = "";

        public static List<Dot> dots = new List<Dot>();
        public static List<Line> lines = new List<Line>();

        public static void CreateDots(int n)
        {
            int r = 100;
            int OX = 250;
            int OY = 200;
            for(int i = 1; i <= n; i++)
            {
                double x, y;
                x = OX + r * Math.Cos(2 * i * Math.PI / n);
                y = OY + r * Math.Sin(2 * i * Math.PI / n);
                dotCount++;
                dots.Add(new Dot((int)x, (int)y, dotCount));
            }
        }

        public static bool CheckLineAviability(Dot firstDot, Dot secondDot)
        {
            foreach(Line x in lines)
            {
                if (x.dot1 == firstDot && x.dot2 == secondDot)
                    return false;
            }

            return true;
        }

        public static Dot FindByInd(int ind)
        {
            Dot temp = new Dot(0, 0, 0);
            for (int i = 0; i < dots.Count(); i++)
            {
                if (dots[i].DotInd == ind)
                {
                    temp = dots[i];
                }
            }
            return temp;
        }

        public static int[,] CreateIncMatrix()
        {
            int[,] resultMatrix = new int[dots.Count, lines.Count];

            for(int i = 0; i < dots.Count; i++)
            {
                for(int j = 0; j < lines.Count; j++)
                {
                    resultMatrix[i, j] = 0;
                }
            }

            for(int j = 0; j < lines.Count; j++)
            {
                resultMatrix[lines[j].dot1.DotInd - 1, j] = 1;
                resultMatrix[lines[j].dot2.DotInd - 1, j] = -1;
            }

            return resultMatrix;
        }

        public static int[,] CreateAdjMatrix()
        {
            int[,] res = new int[dots.Count, dots.Count];

            for(int i = 0; i < dots.Count; i++)
            {
                for(int j = 0; j < dots.Count; j++)
                {
                    res[i, j] = 0;
                }
            }

            foreach(var x in lines)
            {
                res[x.dot1.DotInd - 1, x.dot2.DotInd - 1] = 1;
            }

            return res;
        }

        public static int[,] Multiplication(int[,] a, int[,] b)
        {
            int[,] r = new int[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return r;
        }

        public static int[,] Addiction(int[,] a, int[,] b)
        {
            int[,] r = new int[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    r[i, j] = a[i, j] + b[i, j];
                }
            }
            return r;
        }

        public static int[,] CreateEMatrix(int n)
        {
            int[,] r = new int[n, n];

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if(i == j)
                    {
                        r[i, j] = 1;
                        continue;
                    }
                    else
                    {
                        r[i, j] = 0;
                    }
                }
            }
            return r;
        }

        public static int[,] CreateAviMatrix()
        {
            int[,] res = Addiction(CreateAdjMatrix(), CreateEMatrix(dots.Count));

            var adjMatrix = CreateAdjMatrix();
            var firstOperand = adjMatrix;

            for (int n = 1; n < dots.Count; n++)
            {
                int[,] tempRes = Multiplication(firstOperand, adjMatrix);

                for (int i = 0; i < dots.Count; i++)
                {
                    for (int j = 0; j < dots.Count; j++)
                    {
                        res[i, j] += tempRes[i, j];
                    }
                }

                firstOperand = tempRes;
            }
            return res;
        }
    }
}
