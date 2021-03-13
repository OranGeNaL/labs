using System;
using System.IO;

namespace Practice2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task1();
            // Task2();
            // Task3();
            // Task4();
            // Task5();
            // Task6();
            // Task7();
            // Task8();
            // Task9();
            // Task10();
            Task11();
        }

        static void Task1()
        {
            Console.Write("Введите координату x >>> ");
            string buf = Console.ReadLine();
            double x = Convert.ToDouble(buf);
            Console.Write("Введите координату у >>> ");
            buf = Console.ReadLine();
            double y = double.Parse(buf);
            int kol = 0;
            if (x * x + y * y < 1)
                kol = 2;
            else if (x * x + y * y < 4)
                kol = 1;
            Console.WriteLine("Результат = {0} очков", kol);
            Console.ReadKey();
        }

        static void Task2()
        {
            string buf;
            double a, b, res;
            Console.Write("Введите первый операнд: ");
            buf = Console.ReadLine();
            a = double.Parse(buf);
            Console.Write("Введите знак операции: ");
            char op = (char) Console.Read();
            Console.ReadLine();
            Console.Write("Введите второй операнд: ");
            buf = Console.ReadLine();
            b = double.Parse(buf);
            bool ok = true;
            switch (op)
            {
                case '+':
                    res = a + b;
                    break;
                case '-':
                    res = a - b;
                    break;
                case '*':
                    res = a * b;
                    break;
                case '/':
                    res = a / b;
                    break;
                default:
                    res = double.NaN;
                    ok = false;
                    break;
            }

            if (ok)
                Console.WriteLine("Результат: " + res);
            else
                Console.WriteLine("Недопустимая операция");
            Console.ReadKey();

        }

        static void Task3()
        {
            double Xn = -2, Xk = 12, dX = 2, t = 2, y;
            Console.WriteLine("| x | у |"); // заголовоктаблицы
            double x = Xn; //1
            while (x <= Xk) //5
            {
                y = t; //2
                if (x >= 0 && x < 10)
                    y = t * x; //2
                if (x >= 10)
                    y = 2 * t; //2                                        
                Console.WriteLine("| {0,6} | {1,6} |", x, y); //3
                x += dX; //4
            }

            Console.ReadKey();
        }
        
        static void Task4()
        {
            string buf;
            while (true)
            {
                Console.WriteLine("1 - пункт_1, 2 - пункт_2, 3 - выход");
                buf = Console.ReadLine();
                switch (buf)
                {
                    case "1": // Вставить код обработки пункта 1
                        Console.WriteLine("отладка - пункт_1");
                        break;
                    case "2": // Вставить код обработки пункта 2
                        Console.WriteLine("отладка - пункт_2");
                        break;
                    case "3": return;
                    default:
                        Console.WriteLine("не попал по клавише!");
                        break;
                }
            }
        }
        
        static void Task5()
        {
            char answer;
            do
            {
                Console.WriteLine("Купи слоника, a?");
                answer = (char)Console.Read();
                Console.ReadLine();
            }
            while (answer != 'y' );
        }
        
        static void Task6()
        {
            double Xn = -2, Xk = 12, dX = 2, t = 2, y;
            Console.WriteLine("| x | у |"); // заголовоктаблицы
            for (double x = Xn; x <= Xk; x += dX)   // 1, 4, 5
            {
                y = t; //2
                if (x >= 0 && x < 10)
                    y = t * x;  // 12
                if (x >= 10)
                    y = 2 * t; // 2
                Console.WriteLine("| {0,6} | {1,6} |", x, y);   //3

            }
            Console.ReadKey();
        }

        static void Task7()
        {
            double e = 1e-6;
            const int Maxlter = 500;    // ограничитель количества итераций
            Console.Write("Введите аргумент: ");
            string buf = Console.ReadLine();
            double x = Convert.ToDouble(buf);
            bool done = true;   // признак достижения точности
            double ch = 1, у = ch;
            for (int n = 0; Math.Abs(ch) > e; n++)
            {
                ch *= x * x / (2 * n + 1) / (2 * n + 2);
                у += ch; // добавление члена ряда к сумме
                if (n > Maxlter)
                {
                    done = false;
                    break;
                }
            }
            if (done) Console.WriteLine("Суммаряда - " + у );
            else Console.WriteLine( "Рядрасходится" );
            Console.ReadKey();

        }
        
        static void Task8()
        {
            int j;
            Console.WriteLine("\n\n Одномерный массив iArray");
            int[] iArray = new int[10];
            for (j = 0; j < 10;j++)
                iArray[j] = j * j;
// присваивание значений
// элементам в цикле
            for (j = 0; j < 10;j++) // вывод элементов
                Console.WriteLine("\n " + j + " "+ iArray[j]);
            Console.WriteLine("\n Одномерный массив chArray с инициализацией");
            char[] chArray = { 'a', 'b', 'c', 'd' }; // Объявление с инициализацией
            j = -1;
            do
            {
                j++;
                Console.WriteLine("\n " + j + " " + chArray[j]);
            }
            while (chArray[j] != 'd'); // вывод элементов массива
            Console.WriteLine();
            Console.Write("\n Значения присвоены ");
            Console.WriteLine("Heвсем элементамассива iiArray \n");
            int[] iiArray = new int[10];
            for (j = 0; j < 6; j++)
                iiArray[j] = j * j;
            iiArray[9] = 81;
            foreach (int jj in iiArray)
            { Console.Write(" " + jj); }
            Console.WriteLine("\n\n");
            Console.Write(" ");
        }

        static void Task9()
        {
            int j; // начальное значение
            string strValue;
            int[] iArray = new int[10];
            for (j = 0; j < 10; j++)
            {
                strValue = Console.ReadLine(); // ввод и присваивание значений
                iArray[j]= Convert.ToInt32(strValue);
            }
            for (j = 0; j < 10; j++) // вывод элементов
                Console.WriteLine("\n " + j + " " + iArray[j]);
        }
        
        static void Task10()
        {
            int j, num1, num2;
            string str;
            double db1, db2;
            Random rnd = new Random();
            int[] iArray1 = new int[10];
            int[] iArray2 = new int[10];
            double[] dArray1 = new double[10];
            double[] dArray2 = new double[10];
            for (j = 0; j < 10; j++)
            {
                iArray1[j] = rnd.Next(1, 101);
                iArray2[j] = 50 - rnd.Next(1, 101);
            }

            for (j = 0; j < 10; j++)
            {
                num1 = rnd.Next(1, 101);
                db1 = Convert.ToDouble(num1);
                dArray1[j] = db1 + Convert.ToDouble(rnd.Next(1, 101)) / 100;
                num2 = 50 - rnd.Next(1, 101);
                db2 = Convert.ToDouble(num2);
                dArray2[j] = db2 - Convert.ToDouble(rnd.Next(1, 101)) / 100;
            }

            Console.WriteLine("\n  -------------------------- -------");
            Console.WriteLine("\n Массивы типа int Массивы типа double");
            Console.WriteLine("\n  ----------------------------------");
            for (j = 0; j < 10; j++)
            {
                str = string.Format("\n {0, 4:D} {1, 6:D} {2, 6:D} {3, 8:D} {4, 8:F2} {5, 8:F2}",
                    j, iArray1[j], iArray2[j], j, dArray1[j], dArray2[j]);
                Console.WriteLine(str);
                Console.WriteLine("\n  ----------------------------------");
                Console.WriteLine();
            }
        }

        static void Task11()
        {
            int j;
            string strValue;
            int[ ] iArray1= new int[10];
            int[ ]iArray2 = new int[10];
            StreamReader sRead = new StreamReader("text.txt");
            StreamWriter sWrite = new StreamWriter ("textO.txt");
            for (j = 0; j < 10; j++)
            {
                strValue = sRead.ReadLine();
                iArray1[j] = Convert.ToInt32(strValue);
                iArray2[j] = 10 * iArray1 [j];
                strValue = string.Format("\n {0, 4:D} {1, 6:D} {2, 6:D}", j, iArray1[j], iArray2[j]);
                Console.WriteLine(strValue);
                Console.WriteLine();
                sWrite.WriteLine(iArray2[j]);
            }
            sRead.Close();
            sWrite.Close();
        }
    }
}