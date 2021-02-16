using System;

namespace ValyaLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            //First();
            //Second();
            Third();
        }

        static void First()
        {
            Console.Write("Введите переменную A(int): ");
            int A = int.Parse(Console.ReadLine());
            Console.Write("Введите переменную I(int): ");
            int I = int.Parse(Console.ReadLine());
            Console.Write("Введите переменную C(double): ");
            double C = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите переменную L(bool): ");
            bool L = bool.Parse(Console.ReadLine());
            Console.Write("Введите переменную N(string): ");
            string N = Console.ReadLine();

            Console.Write($"\nA = {A}\nI = {I}\nC = {C}\nL = {L}\nN = {N}\n");
        }

        static void Second()
        {
            Console.Write("x: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("y: ");
            double y = double.Parse(Console.ReadLine());
            Console.Write("z: ");
            double z = double.Parse(Console.ReadLine());

            try
            {
                double znam = x * x * x + z * z;
                if(znam == 0)
                    throw new DivideByZeroException();

                Console.WriteLine("F = {0}", Math.Pow(Math.Min(x, Math.Max(x + z, y)), 2)/znam);
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Third()
        {
            Console.Write("x: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("y: ");
            double y = double.Parse(Console.ReadLine());

            int N = 0;
            double r = Math.Sqrt(x * x + y * y);
            double phi = Math.Acos(x / r);

            if(r > 12)
            {
                N = 4;
            } else if ((phi >= 0 && phi <= Math.PI/2) || (phi >= Math.PI && phi <= Math.PI*3.0/2) )
            {
                if (y > 0)
                    N = 2;
                else
                    N = 3;
            }
            else if (phi > Math.PI/2 && phi < Math.PI)
            {
                if (y < 0)
                    N = 2;
                else
                    N = 1;
            }
            else
            {
                N = 3;
            }

            Console.WriteLine($"Точка принадлежит области под номером {N}");
        }
    }
}
