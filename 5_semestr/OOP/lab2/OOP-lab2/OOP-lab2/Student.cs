using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_lab2
{
    class Student : Human
    {
        public string Group { get; private set; }

        public Student(string name, int age, string group) : base(name, age) 
        {
            Group = group;
            Console.WriteLine("Создан студент: Имя - {0} Возраст - {1} Группа - {2}", Name, Age, Group);
        }

        public override void WhoAmI()
        {
            Console.WriteLine("Меня зовут: {0}, Мне {1} лет. Я Студент.", Name, Age);
        }
    }
}
