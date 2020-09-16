using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Prog
{
    class Person
    {
        public string Name { get; private set; }
        public int Age { get; private set; }

        public string destrSignalizer = "Object exists";

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
            destrSignalizer = null;
            Console.WriteLine("Сработал деструктор!");
            Console.Beep();
            FileStream fs = new FileStream("destr.txt", FileMode.Create);
            byte[] buf = Encoding.Default.GetBytes(string.Format("Сработал деструктор! Имя: {0}; Возраст: {1}", Name, Age));
            fs.Write(buf, 0, buf.Length);
            fs.Close();
            System.Diagnostics.Trace.WriteLine(string.Format("Сработал деструктор! Имя: {0}; Возраст: {1}", Name, Age));
        }
    }
}
