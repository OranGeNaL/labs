using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MO_lab2
{
    public class Simplex
    {
        double[,] table; //симплекс таблица

        int m, n; // m - количество базисных переменных (количество уравнений)
                  // n - количество переменных

        List<int> basis; //список базисных переменных

        bool endResult = true; // true - разрешима; false - неразрешима

        public Simplex(double[,] source)
        {
            m = source.GetLength(0);
            n = source.GetLength(1);
            table = new double[m, n + m - 1];
            basis = new List<int>();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (j < n)
                        table[i, j] = source[i, j];
                    else
                        table[i, j] = 0;
                }
                //выставляем коэффициент 1 перед базисной переменной в строке
                if ((n + i) < table.GetLength(1))
                {
                    table[i, n + i] = 1;
                    basis.Add(n + i);
                }
            }

            n = table.GetLength(1);
        }

        public void Calculate()
        {
            double[] result = new double[table.GetLength(1) - 1];
            int mainCol, mainRow; //ведущие столбец и строка

            Console.WriteLine("Исходная таблица");
            OutTable(-1, -1);
            //WriteCap(table.GetLength(1) + 1);
            //Console.WriteLine("------------------------------------");

            while (!IsItEnd() && endResult)
            {
                mainCol = findMainCol();
                mainRow = findMainRow(mainCol);
                basis[mainRow] = mainCol;

                double[,] new_table = new double[m, n];

                for (int j = 0; j < n; j++)
                    new_table[mainRow, j] = table[mainRow, j] / table[mainRow, mainCol];

                for (int i = 0; i < m; i++)
                {
                    if (i == mainRow)
                        continue;

                    for (int j = 0; j < n; j++)
                        new_table[i, j] = table[i, j] - table[i, mainCol] * new_table[mainRow, j];
                }

                OutTable(mainRow, mainCol);
                table = new_table;
            }

            //заносим в result найденные значения X
            for (int i = 0; i < result.Length; i++)
            {
                int k = basis.IndexOf(i + 1);
                if (k != -1)
                    result[i] = table[k, 0];
                else
                    result[i] = 0;
            }

            WriteCap(table.GetLength(1) + 1);

            if (endResult)
            {
                Console.WriteLine("Симплекс таблица, соответствующая оптимальному плану:");
                OutTable(-1, -1);

                Console.WriteLine();
                Console.WriteLine("Решение:");
                for (int i = 0; i < result.GetLength(0); ++i)
                {
                    Console.WriteLine("X_" + (i + 1) + " = " + Math.Round(result[i], 2));
                }
                Console.WriteLine("Z max = " + Math.Round(table[table.GetLength(0) - 1, 0], 2));
            }
            else
            {
                Console.WriteLine("Система неразрешима из-за неограниченности целевой функции в ОДР");
                OutTable(-1, -1);
            }
        }

        private void OutTable(int mainRow, int mainCol)
        {
            Console.WriteLine();
            if (mainRow >= 0 || mainCol >= 0)
            {
                WriteCap(table.GetLength(1) + 2);
            }
            Console.Write(PlaceIntoTable("basis", 10));
            for(int head_num = 1; head_num < n; ++head_num)
            {
                Console.Write(PlaceIntoTable("x_" + (head_num), 10));
            }
            Console.Write(PlaceIntoTable("A0", 10));

            if (mainRow >= 0 || mainCol >= 0)
            {
                Console.WriteLine(PlaceIntoTable("thehta", 10));
                WriteCap(table.GetLength(1) + 2);
            }
            else
            {
                WriteCap("\n", table.GetLength(1) + 1);
            }

            for(int row = 0; row < m; ++row)
            {
                for(int coloumn = 0; coloumn < n; ++coloumn)
                {
                    if(coloumn == 0)
                    {
                        Console.Write(PlaceIntoTable((row < basis.Count ? "x_" + basis[row] : " "), 10));
                    }
                    else
                    {
                        if(row == mainRow && coloumn == mainCol)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        Console.Write(PlaceIntoTable(Math.Round(table[row, coloumn], 2).ToString(), 10));
                    }
                    
                }
                Console.Write(PlaceIntoTable(Math.Round(table[row, 0], 2).ToString(), 10));

                if ((mainRow >= 0 || mainCol >= 0) && row < basis.Count)
                {
                    if(table[row, mainCol] > 0)
                    {
                        Console.WriteLine(PlaceIntoTable(Math.Round(table[row, 0] / table[row, mainCol], 2).ToString(), 10));
                    }
                    else
                    {
                        Console.WriteLine(PlaceIntoTable("-", 10));
                    }
                }
                else
                {
                    Console.WriteLine();
                }
                    
            }

            //Console.WriteLine();
        }

        private bool IsItEnd()
        {
            bool flag = true;

            for (int j = 1; j < n; j++) // проверка оценок 
            {
                if (table[m - 1, j] < 0) // если оценка меньше 0
                {
                    int counter = 0;
                    for(int row = 0; row < m - 1; ++row)
                    {
                        if(table[row, j] > 0) // если для такой оценки в столбце есть хотябы один элемент > 0, то это не конец
                        {
                            flag = false;
                            break;
                        }
                        else
                        {
                            ++counter;
                        }
                    }

                    if(counter == m - 1) // если все элементы столбца отрицательные, то система неразрешима
                    {
                        endResult = false;
                        break;
                    }

                }
            }

            return flag;
        }

        private int findMainCol()
        {
            int mainCol = 1;

            for (int j = 2; j < n; j++)
                if (table[m - 1, j] < table[m - 1, mainCol])
                    mainCol = j;

            return mainCol;
        }

        private int findMainRow(int mainCol)
        {
            int mainRow = 0;

            for (int i = 0; i < m - 1; i++)
                if (table[i, mainCol] > 0)
                {
                    mainRow = i;
                    break;
                }

            for (int i = mainRow + 1; i < m - 1; i++)
                if ((table[i, mainCol] > 0) && ((table[i, 0] / table[i, mainCol]) < (table[mainRow, 0] / table[mainRow, mainCol])))
                    mainRow = i;

            return mainRow;
        }

        private void WriteCap(int n)
        {
            string basic = "-----------";
            var result = "";

            for (int i = 0; i < n; i++)
            {
                result += basic;
            }

            Console.WriteLine(result);
        }

        private void WriteCap(string pref, int n)
        {
            string basic = "-----------";
            var result = pref;

            for (int i = 0; i < n; i++)
            {
                result += basic;
            }

            Console.WriteLine(result);
        }

        public static string PlaceIntoTable(string value, int n)
        {
            while (value.Length < n)
            {
                value = value.Insert(0, " ");
            }

            return value + "|";
        }
    }
}
