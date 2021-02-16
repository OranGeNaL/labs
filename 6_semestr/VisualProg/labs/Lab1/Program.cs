using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            //FirstTask();
            //SecondTask();
            ThirdTask();
        }

        static void FirstTask()
        {
            float A = float.Parse(Console.ReadLine());
            int I = int.Parse(Console.ReadLine());
            double C = double.Parse(Console.ReadLine());
            bool L = Convert.ToBoolean(Console.ReadLine());
            string N = Console.ReadLine();

            Console.WriteLine("A: {0,7:F5}\n", A);
            Console.WriteLine("I: {0,5:D5}\n", I);
            Console.WriteLine("C: {0,7:F5}\n", C);
            Console.WriteLine("L: {0}\n", L);
            Console.WriteLine("N: {0}\n", N);
        }

        static void SecondTask()
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double z = double.Parse(Console.ReadLine());

            double znam = x * x + Math.Max(z * z * z, x * y);
            if (znam == 0)
            {
                Console.WriteLine("0 в знаменателе!!!");
                return;
            }

            Console.WriteLine("Результат: {0}", Math.Min(x * x, y + z) / znam);
        }

        static void ThirdTask()
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            if(Math.Sqrt(x*x + y*y) > 12)
            {
                Console.WriteLine("Точка входит в область 4.");
                return;
            }

            if(x*y >= 0)
            {
                Console.WriteLine("Точка входит в область 2.");
                return;
            }

            if(x < 0)
            {
                Console.WriteLine("Точка входит в область 1.");
                return;
            }

            Console.WriteLine("Точка входит в область 3.");
        }
    }
}
