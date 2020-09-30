﻿using System;

namespace Prog
{
    class Program
    {
        static void Main(string[] args)
        {
            int ans = 0;
            ListContainer<string> list = new ListContainer<string>();
            while(true)
            {
                Console.WriteLine("1. Вставить в начало списка\n2. Вставить в конец списка\n3. Вывести список\n4. Вытолкнуть из начала\n5. Вытолкнуть из конца\n");
                Console.Write("Выберите команду >>> ");
                ans = int.Parse(Console.ReadLine());
                switch (ans)
                {
                    case 1:
                        Console.Write("Введите данные для сохранения >>> ");
                        var i = list < Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Введите данные для сохранения >>> ");
                        var j = list <= Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine(list.ToString());
                        break;
                    case 4:
                        Console.WriteLine("{0} вытолкнуто из начала.", list > 0);
                        break;
                    case 5:
                        Console.WriteLine("{0} вытолкнуто из конца.", list >= 0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
