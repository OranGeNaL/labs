using System;
using System.Collections.Generic;

namespace OOP_lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            bool a = true;
            while(a)
            {
                Console.WriteLine("Выберите команду:\n1) Создать Преподавателя\n2) Создать Студента\n3) Выйти из программы");
                Console.Write("   >>>");
                int ans = 0;
                try
                {
                    ans = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Вводите число!");
                }
                string name;
                int age;
                switch (ans)
                {
                    case 1:
                        Console.Write("Введите имя: ");
                        name = Console.ReadLine();
                        Console.Write("Введите возраст: ");
                        age = int.Parse(Console.ReadLine());
                        Console.Write("Введите кафедру: ");
                        string kafedra = Console.ReadLine();
                        Prepod prepod = new Prepod(name, age, kafedra);
                        prepod.WhoAmI();
                        break;
                    case 2:
                        Console.Write("Введите имя: ");
                        name = Console.ReadLine();
                        Console.Write("Введите возраст: ");
                        age = int.Parse(Console.ReadLine());
                        Console.Write("Введите группу: ");
                        string group = Console.ReadLine();
                        Student student = new Student(name, age, group);
                        student.WhoAmI();
                        break;
                    case 3:
                        a = false;
                        break;
                    default:
                        Console.WriteLine("Выберите команду из списка");
                        break;
                }

            }
            */

            List<Human> list = new List<Human>();
            list.Add(new Human("Данил", 20));
            list.Add(new Prepod("Максим", 35, "ПО"));
            list.Add(new Student("Никита", 20, "ПО(аб)-81"));

            foreach (var i in list)
                i.WhoAmI();
        }
    }
}
