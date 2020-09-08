using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_lab2
{
    class Human
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        
        public void WhoAmI()
        {
            Console.WriteLine("Меня зовут: {0}, Мне {1} лет.", Name, Age);
        }

        public Human(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
