using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_lab2
{
    class Prepod : Human
    {
        public string Kafedra { get; private set; }

        public Prepod(string name, int age, string kafedra) : base(name, age)
        {
            Kafedra = kafedra;
            Console.WriteLine("Создан преподаватель: Имя - {0} Возраст - {1} Кафедра - {2}", Name, Age, Kafedra);
        }

        public override void WhoAmI()
        {
            Console.WriteLine("Меня зовут: {0}, Мне {1} лет. Я преподаватель.", Name, Age);
        }
    }
}
