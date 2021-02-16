using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice1
{
    static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Console.Write("Номер примера: ");
            int choise = int.Parse(Console.ReadLine());

            try
            {
                if(choise < 1 || choise > 11)
                {
                    throw new Exception("Неверный номер!");
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }

            switch (choise)
            {
                case 1:
                    FirstExample();
                    break;
                case 2:
                    SecondExample();
                    break;
                case 3:
                    ThirdExample();
                    break;
                case 4:
                    FourthExample();
                    break;
                case 5:
                    FifthExample();
                    break;
                case 6:
                    SixthExample();
                    break;
                case 7:
                    SeventhExample();
                    break;
                case 8:
                    EighthExapmle();
                    break;
                case 9:
                    NinthExample();
                    break;
                case 10:
                    TenthExaple();
                    break;
                case 11:
                    EleventhExaple();
                    break;
            }

            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }

        static void FirstExample()
        {
            MessageBox.Show("Hello!");
        }

        static void SecondExample()
        {
            int i = 3;
            double y = 4.12;
            decimal d = 600m;

            string s = "Вася";
            Console.Write(i);
            Console.WriteLine("y = " + y);
            Console.WriteLine("d = " + d + " s = " + s);

        }

        static void ThirdExample()
        {
            int i = 3;
            double y = 4.12;
            decimal d = 600m;
            string s = "Вася";

            Console.Write(i);
            Console.Write(" y = {0}\nd = {1}", y, d);
            Console.WriteLine(" s = " + s);
        }

        static void FourthExample()
        {
            int i = 3;
            double y = 4.12;
            int d = 600;
            string s = "Вася";

            Console.Write(i);
            Console.Write(" y = {0:f2}\nd = {1:d3}", y, d);
            Console.WriteLine(" s = " + s);
        }

        static void FifthExample()
        {
            double y = 4.12;

            Console.Write("y = {0,5:0.# 'руб.'}\n", y);
        }

        static void SixthExample()
        {
            string s = Console.ReadLine();
            char c = (char)Console.Read();
            Console.ReadLine();
            string buf = Console.ReadLine();
            int i = Convert.ToInt32(buf);
            buf = Console.ReadLine();
            double x = Convert.ToDouble(buf);
            buf = Console.ReadLine();
            double y = double.Parse(buf);

            Console.WriteLine("s = " + s + " c = " + c + " i = " + i + " x = " + x + " y = " + y);
                
        }

        static void SeventhExample()
        {
            string s = Console.ReadLine();
            char c = (char)Console.Read();
            Console.ReadLine();
            int i = Convert.ToInt32(Console.ReadLine());
            double x = Convert.ToDouble(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            Console.WriteLine("s = " + s + " c = " + c + " i = " + i + " x = " + x + " y = " + y);
        }

        static void EighthExapmle()
        {
            SeventhExample();
        }

        static void NinthExample()
        {
            Console.Write("Введите температуру в градусах по шкале Фаренгейта: ");
            double fahr = Convert.ToDouble(Console.ReadLine());
            double cels = 5d / 9 * (fahr - 32);
            Console.WriteLine("По Фаренгейту: {0}\nВ градусах Цельсия: {1:F2}", fahr, cels);
        }

        static void TenthExaple()
        {
            int a = -14;
            float c = -0.00151f;
            double i = 1234.56789;
            bool l = false;
            string name = "Petrov";

            Console.WriteLine("name = {0,6}, l = {1,4}", name, l);
            Console.WriteLine("a = {0,4}, c = {1,10:f5}, i = {2,20:e8}\n", a, c, i);
        }

        static void EleventhExaple()
        {
            Console.WriteLine("Введите значение переменной a: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение переменной c: ");
            float c = float.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение переменной i: ");
            double i = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение переменной l: ");
            bool l = bool.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение переменной name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Результаты форматирования:\nname = {0,6}, l = {1,4}", name, l);
            Console.WriteLine("a = {0,4}, c = {1,10:f5}, i = {2,20:e8}\n", a, c, i);
        }
    }
}
