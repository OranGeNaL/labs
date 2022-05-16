using System;

namespace MO_lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*double[,] table = { {25, -3,  5},
                                {30, -2,  5},
                                {10,  1,  0},
                                { 6,  3, -8},
                                { 0, -6, -5} };*/

            /*double[,] table = { {13,  1,  2,  3},   // лекционный пример
                                {9 ,  2,  1,  4},
                                {32,  4,  3,  1},
                                {0 , -1, -2, -3}};*/

            double[,] table2 = { {20,  1,  -2,  2},   // вторая система
                                {16,  1,  -4, -1},
                                {0 ,  -5, -4, 1}};

            double[,] table1 = { {10,  1,  2,  2},   // первая система
                                {8,  1,  4, -1},
                                {0, -3, -2, -1}};
            
            Simplex S = new Simplex(table2);
            S.Calculate();
        }
    }
}
