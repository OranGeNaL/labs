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
            Person person = new Person(name, age);
        }
    }
}
