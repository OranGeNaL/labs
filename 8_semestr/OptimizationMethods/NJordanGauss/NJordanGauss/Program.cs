using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NJordanGauss
{
    internal class Program
    {
        private static char[] downIndexes = new[]
        {
            '\u2080',
            '\u2081',
            '\u2082',
            '\u2083',
            '\u2084',
            '\u2085',
            '\u2086',
            '\u2087',
            '\u2088',
            '\u2089',
        };
        
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Введите количество уравнений: ");
            int rowsCount = int.Parse(Console.ReadLine());
            Console.Write("Введите количество неизвестных: ");
            int columnCount = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            // double[,] doubleCoeffMatrix = new double[,]
            // {
            //     // { 2, 3, 1, 2, 12 },
            //     // { 1, 4, 2, -1, 8 },
            //     // { 3, 2, 3, 2, 24 }
            //     // {1, -2, 1, -1, 0},
            //     // {2, 1, 3, 1, 5},
            //     // {1, 3, 1, 2, 2}
            //     { 2, 1, 3, 1, 6 },
            //     { 1, 3, 3, 2, 7 },
            //     { 2, 6, 6, 4, 14}
            // };

            double[,] doubleCoeffMatrix = new double[rowsCount, columnCount + 1];

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnCount + 1; j++)
                {
                    if (j == columnCount)
                    {
                        Console.Write("Введите правую часть {0}-го уравнения: ", i + 1);
                        doubleCoeffMatrix[i, j] = int.Parse(Console.ReadLine());
                        continue;
                    }
                    
                    Console.Write("Введите x{0} {1}-го уравнения: ", downIndexes[j + 1], i + 1);
                    doubleCoeffMatrix[i, j] = int.Parse(Console.ReadLine());
                }
            }


            Coefficient[,] coefficients =
                new Coefficient[doubleCoeffMatrix.GetLength(0), doubleCoeffMatrix.GetLength(1)];

            for (int i = 0; i < doubleCoeffMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < doubleCoeffMatrix.GetLength(1); j++)
                {
                    coefficients[i, j] = new Coefficient(doubleCoeffMatrix[i, j]);
                }
            }

            Console.WriteLine("Исходная таблица:");
            Console.WriteLine(GetCap(coefficients.GetLength(1)));
            for (int j = 0; j < coefficients.GetLength(0); j++)
            {
                for (int k = 0; k < coefficients.GetLength(1); k++)
                {
                    Console.Write(PlaceIntoTable(coefficients[j, k].ToString(), 10));
                }
                Console.WriteLine("");
            }
            Console.WriteLine(GetCap(coefficients.GetLength(1)) + "\n\n");

            switch (ConvertToBasis(coefficients))
            {
                case 0:
                    Console.WriteLine("Итоговая матрица:");
                    Console.WriteLine(GetCap(coefficients.GetLength(1)));
                
                    for (int n = 0; n < coefficients.GetLength(0); n++)//Вывод таблицы в консоль
                    {
                        for (int k = 0; k < coefficients.GetLength(1); k++)
                        {
                            Console.Write(PlaceIntoTable(coefficients[n, k].ToString(), 10));
                        }
                        Console.WriteLine("");
                    }
                    Console.WriteLine(GetCap(coefficients.GetLength(1)) + "\n\n");
                    Solve(coefficients);
                    break;
                case -1:
                    Console.WriteLine("Данная СЛАУ несовместна");
                    break;
                case -2:
                    Console.WriteLine("Данная СЛАУ линейно зависима");
                    List<int> nulls = new List<int>();
                    for (int i = 0; i < coefficients.GetLength(0); i++)
                    {
                        double roundSum = 0;

                        for (int k = 0; k < coefficients.GetLength(1); k++)
                        {
                            roundSum += coefficients[i, k].GetDouble();
                        }

                        if (roundSum == 0)
                        {
                            nulls.Add(i);
                        }
                    }

                    Coefficient[,] cuttedCoefficients = new Coefficient[coefficients.GetLength(0) - nulls.Count,
                        coefficients.GetLength(1)];
                    for (int i = 0; i < coefficients.GetLength(0) - nulls.Count; i++)
                    {
                        for (int j = 0; j < coefficients.GetLength(1); j++)
                        {
                            cuttedCoefficients[i, j] = coefficients[i, j];
                        }
                    }
                    
                    Solve(cuttedCoefficients);
                    break;
            }
            
        }

        public static void Solve(Coefficient[,] coefficients)
        {
            if (coefficients.GetLength(0) < coefficients.GetLength(1) - 1)
            {
                Console.WriteLine("\nСистема неопределенная");

                List<string> commonResolve = new List<string>();
                List<string> basisResolve = new List<string>();

                for (int i = 0; i < coefficients.GetLength(0); i++)
                {
                    int basis = 0;
                    List<int> freeElements = new List<int>();
                    
                    for (int j = 0; j < coefficients.GetLength(1) - 1; j++)
                    {
                        if (coefficients[i, j].GetDouble() == 1)
                        {
                            basis = j;
                        }
                        
                        else if (coefficients[i, j].GetDouble() != 0)
                        {
                            freeElements.Add(j);
                        }
                    }
                    
                    basisResolve.Add(string.Format("x{0} = {1}", downIndexes[basis + 1], coefficients[i, coefficients.GetLength(1) - 1]));

                    string freeString = "";
                    
                    foreach (var free in freeElements)
                    {
                        Coefficient flopped = coefficients[i, free] * (-1);
                        freeString += (flopped.GetDouble() > 0 ? " +" : " ") + flopped + "x" + downIndexes[free + 1];
                    }
                    
                    commonResolve.Add(string.Format("x{0} = {1}{2}", downIndexes[basis + 1], coefficients[i, coefficients.GetLength(1) - 1], freeString));
                }

                Console.WriteLine("\nОбщее решение системы:");
                foreach (var c in commonResolve)
                {
                    Console.WriteLine(c);
                }
                
                Console.WriteLine("Базисное решение системы:");
                foreach (var b in basisResolve)
                {
                    Console.WriteLine(b);
                }
            }
            
            else if (coefficients.GetLength(0) == coefficients.GetLength(1) - 1)
            {
                Console.WriteLine("\nСистема определенная");

                List<string> basisResolve = new List<string>();

                for (int i = 0; i < coefficients.GetLength(0); i++)
                {
                    int basis = 0;
                    
                    for (int j = 0; j < coefficients.GetLength(1) - 1; j++)
                    {
                        if (coefficients[i, j].GetDouble() == 1)
                        {
                            basis = j;
                        }
                    }
                    
                    basisResolve.Add(string.Format("x{0} = {1}", downIndexes[basis + 1], coefficients[i, coefficients.GetLength(1) - 1]));
                }
                
                Console.WriteLine("Решение системы:");
                foreach (var b in basisResolve)
                {
                    Console.WriteLine(b);
                }
            }
        }
        public static int ConvertToBasis(Coefficient[,] coefficients)
        {
            for (int i = 0; i < coefficients.GetLength(0); i++)
            {
                int bestCoeff = 0; //Находим разрешающий элемент в i-той строке
                // for (int j = 0; j < coefficients.GetLength(1) - 1; j++)
                // {
                //     if (coefficients[i, bestCoeff].GetDouble() == 0 && coefficients[i, j].GetDouble() != 0)
                //     {
                //         bestCoeff = j;
                //     }
                //     if (Math.Abs(1 - Math.Abs(coefficients[i, j].GetDouble())) < Math.Abs((1 - Math.Abs(coefficients[i, bestCoeff].GetDouble()))) && 
                //         coefficients[i, j].GetDouble() != 0)
                //     {
                //         bestCoeff = j;
                //     }
                // }

                bestCoeff = i;
                if (coefficients[i, i].GetDouble() == 0)
                {
                    for (int j = 0; j < coefficients.GetLength(1); j++)
                    {
                        if (j == i || coefficients[i, j].GetDouble() == 0)
                        {
                            continue;
                        }

                        bestCoeff = j;
                    }
                }
                
                Console.WriteLine("Разрешающий элемент строки {0} находится в столбце {1}", i + 1, bestCoeff + 1);
                Console.WriteLine(GetCap(coefficients.GetLength(1)));
                
                for (int j = 0; j < coefficients.GetLength(0); j++)//Вывод таблицы в консоль
                {
                    for (int k = 0; k < coefficients.GetLength(1); k++)
                    {
                        if (j == i && k == bestCoeff)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(PlaceIntoTable(coefficients[j, k].ToString(), 10));
                            Console.ResetColor();
                            continue;
                        }
                        
                        Console.Write(PlaceIntoTable(coefficients[j, k].ToString(), 10));
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine(GetCap(coefficients.GetLength(1)) + "\n\n");

                for (int j = 0; j < coefficients.GetLength(0); j++)
                {
                    Coefficient semiSolver = coefficients[j, bestCoeff] / coefficients[i, bestCoeff];

                    Coefficient resolver = coefficients[j, bestCoeff];
                    
                    for (int k = 0; k < coefficients.GetLength(1); k++)
                    {
                        if (j == i)
                        {
                            coefficients[j, k] /= resolver;
                            continue;
                        }

                        if (k == bestCoeff)
                        {
                            coefficients[j, k] = new Coefficient(0);
                            continue;
                        }
                        
                        coefficients[j, k] -= semiSolver * coefficients[i, k];
                    }
                }

                for (int j = i + 1; j < coefficients.GetLength(0); j++) // Проверка на несовместность
                {
                    double roundSum = 0;

                    for (int k = 0; k < coefficients.GetLength(1) - 1; k++)
                    {
                        roundSum += Math.Abs(coefficients[j, k].GetDouble());
                    }

                    if (roundSum == 0 && coefficients[j, coefficients.GetLength(1) - 1].GetDouble() > 0)
                    {
                        Console.WriteLine("Итоговая матрица:");
                        Console.WriteLine(GetCap(coefficients.GetLength(1)));
                
                        for (int n = 0; n < coefficients.GetLength(0); n++)//Вывод таблицы в консоль
                        {
                            for (int k = 0; k < coefficients.GetLength(1); k++)
                            {
                                Console.Write(PlaceIntoTable(coefficients[n, k].ToString(), 10));
                            }
                            Console.WriteLine("");
                        }
                        Console.WriteLine(GetCap(coefficients.GetLength(1)) + "\n\n");
                        return -1;//Система несовместна
                    }
                }


                List<int> nulls = new List<int>();
                
                for (int j = i + 1; j < coefficients.GetLength(0); j++)
                {
                    double roundSum = 0;

                    for (int k = 0; k < coefficients.GetLength(1); k++)
                    {
                        roundSum += Math.Abs(coefficients[j, k].GetDouble());
                    }

                    if (roundSum == 0)
                    {
                        nulls.Add(j);
                    }
                }

                if (nulls.Count == coefficients.GetLength(0) - i - 1 && nulls.Count != 0) //Проверка на линейную зависимость
                {
                    Console.WriteLine("Итоговая матрица:");
                    Console.WriteLine(GetCap(coefficients.GetLength(1)));
                
                    for (int j = 0; j < coefficients.GetLength(0); j++)//Вывод таблицы в консоль
                    {
                        for (int k = 0; k < coefficients.GetLength(1); k++)
                        {
                            Console.Write(PlaceIntoTable(coefficients[j, k].ToString(), 10));
                        }
                        Console.WriteLine("");
                    }
                    Console.WriteLine(GetCap(coefficients.GetLength(1)) + "\n\n");
                    return -2;//Система линейно зависима
                }
            }
            
            return 0;
        }

        public static string PlaceIntoTable(string value, int n)
        {
            while (value.Length < n)
            {
                value = value.Insert(0, " ");
            }
            
            return value + "|";
        }

        public static string GetCap(int n)
        {
            string basic = "-----------";
            var result = "";

            for (int i = 0; i < n; i++)
            {
                result += basic;
            }
            
            return result;
        }
    }
}