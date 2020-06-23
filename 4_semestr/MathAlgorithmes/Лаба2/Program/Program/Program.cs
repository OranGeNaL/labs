using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите универсальное множество: ");

            Array U = new Array(Console.ReadLine());

            Console.Write("Введите множество A: ");

            Array A = new Array(Console.ReadLine(), U);

            Console.Write("Введите множество B: ");

            Array B = new Array(Console.ReadLine(), U);

            Console.Write("Введите множество C: ");

            Array C = new Array(Console.ReadLine(), U);

            Console.WriteLine("Универсальное множество: " + U.PrintArray() + "\nМножество A: " + A.PrintArray()
                + "\nМножество B: " + B.PrintArray() + "\nМножество C: " + C.PrintArray());

            Array ApC = new Array().Addiction(A, C, U);
            Console.WriteLine("Объединение А и С: " + ApC.PrintArray());
            Array ApCd = new Array().Negation(ApC, U);
            Console.WriteLine("Дополнение объединения А и С: " + ApCd.PrintArray());
            Array BuC = new Array().Multiplication(B, C, U);
            Console.WriteLine("Пересечение B и C: " + BuC.PrintArray());

            Console.WriteLine("Разность дополнения объединения A и C и пересечения B и C: " + new Array().Substraction(ApCd, BuC, U).PrintArray());
        }
    }
}
