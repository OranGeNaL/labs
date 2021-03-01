using System;

namespace Program
{
    class Program
    {
        //третий вариант
        static void Main(string[] args)
        {
            //FirstTask();
            //SecondTask();
           ThirdTask();
        }

        public static void FirstTask()
        {
            float a = 0;
            float xN = 0;
            float xE = 2;
            float dx = 0.05f;

            Console.Write("Введите значение параметра а: ");
            a = float.Parse(Console.ReadLine());

            Console.WriteLine("      a |       x |       y");

            for(float x = xN; x <= xE; x += dx)
            {
                double y = 1 / Math.Sqrt((1 - x*x)*(1 - x * x) + 4 * a * a * x * x);
                Console.WriteLine("{0:F5} | {1:F5} | {2:F5}", a, x, y);
            }
        }

        public static void SecondTask()
        {
            double x = 0;
            Console.Write("1) 1/4\n2) -1/3\n3) 1/2\nВведите номер значения x: ");
            int ans = int.Parse(Console.ReadLine());
            switch (ans)
            {
                case 1:
                    x = 1 / 4.0;
                    break;
                case 2:
                    x = -1 / 3.0;
                    break;
                case 3:
                    x = 1 / 2.0;
                    break;
                default:
                    Console.WriteLine("Неверное значение.");
                    return;
            }

            double yE = Math.Log(1 + 2 * x);

            Console.WriteLine("Точное значение: {0:F5}\nПолученное значение: {1:F5}", yE, RowCount(x));
        }

        public static double RowCount(double x, int i = 1, double sum = 0)
        {
            while(true)
            {
                double nextEl = Math.Pow(-1, i - 1) * Math.Pow(2 * x, i) / i;
                sum += nextEl;
                if (Math.Abs(nextEl) < 0.000001)
                    return sum;
                i++;
            }
        }

        public static void ThirdTask()
        {
            int[] A = new int[15];
            int[] C = new int[10];
            int[] B = new int[10];
            Random random = new Random();
            for (int i = 0; i < 15; i++)
                A[i] = random.Next(-10, 10);
            for (int i = 0; i < 10; i++)
                C[i] = random.Next(-10, 10);
            for (int i = 0; i < 10; i++)
                B[i] = random.Next(-10, 10);

            B[1] = 0;

            Console.WriteLine($"Массив A: {PrintMas(A)}");
            Console.WriteLine($"Массив C: {PrintMas(C)}");
            Console.WriteLine($"Массив B: {PrintMas(B)}");

            Console.WriteLine($"\nМаксимальный элемент в A: {SearchMax(A)[1]}, его индекс: {SearchMax(A)[0]}");
            Console.WriteLine($"Массив С с переставленными элементами: {PrintMas(SwapOddEven(C))}");
            Console.WriteLine($"Упорядоченный указанным образом массив B: {PrintMas(BubbleSort(B, true))}");
            Console.WriteLine($"Отсортированный по возрастанию массив B: {PrintMas(BubbleSort(B))}");
        }

        public static int[] SearchMax(int[] mass)
        {
            int maxInd = 0;
            for(int i = 1; i < mass.Length; i++)
            {
                if (mass[i] >= mass[maxInd])
                    maxInd = i;
            }
            int[] res = new int[2] { maxInd, mass[maxInd] };
            return res;
        }

        public static int[] SwapOddEven(int[] mass)
        {
            if(mass.Length % 2 != 0)
            {
                Console.WriteLine("В таком массиве нельзя поменять четные и нечетные местами!");
                return null;
            }

            int[] res = new int[mass.Length];
            for(int i = 0; i < mass.Length; i += 2)
            {
                res[i] = mass[i + 1];
                res[i + 1] = mass[i];
            }
            return res;

        }

        public static int[] BubbleSort(int[] mass, bool reverse = false)
        {
            int[] res = mass;

            for(int i = res.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (reverse)
                    {
                        if (res[j] <= res[j + 1])
                        {
                            int a = res[j + 1];
                            res[j + 1] = res[j];
                            res[j] = a;
                        }
                    }
                    else
                    {
                        if (res[j] >= res[j + 1])
                        {
                            int a = res[j + 1];
                            res[j + 1] = res[j];
                            res[j] = a;
                        }
                    }
                }
            }

            return res;
        }

        public static string PrintMas(int[] mass)
        {
            string res = "";
            foreach(var i in mass)
                res += i + ", ";
            return res;
        }

    }
}
