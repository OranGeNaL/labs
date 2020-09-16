using System;

namespace Prog
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите возраст: ");
            int age = int.Parse(Console.ReadLine());
            Pers(name, age);
            Console.ReadKey();
            //Console.Beep();
        }

        static void Pers(string name, int age)
        {
            Person person = new Person(name, age);
        }
    }
}
