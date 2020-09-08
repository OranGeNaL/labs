using System;
using System.Collections.Generic;
using System.Text;

namespace Prog
{
    class Person
    {
        public string Name { get; private set; }
        public int Age { get; private set; }

        public Person()
        {

        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            Console.WriteLine("Сработал конструктор! Имя: {0}; Возраст: {1}", Name, Age);
        }

        ~Person()
        {
            Console.WriteLine("Сработал деструктор!");
        }
    }
}
