using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Зашифровать[1] или дешифровать[2]? ");
            int mode = Int32.Parse(Console.ReadLine());

            Console.Write("Введите ключ: ");
            string key = Console.ReadLine();

            Playfair playfair = new Playfair();

            if (mode == 1)
            {
                Console.Write("Введите текст: ");
                string plainText = Console.ReadLine();
                string encodedText = playfair.execute(key, plainText, true);

                Console.WriteLine($"Зашифрованный текст: {encodedText}");
                Console.WriteLine($"Зашифрованный текст по биграммам: {Playfair.ToBigrammString(encodedText)}");
            }
            else
            {
                Console.Write("Введите шифротекст: ");
                string encodedText = Console.ReadLine();
                string plainText = playfair.execute(key, encodedText, false);

                Console.WriteLine($"Расшифрованный текст*: {plainText}");
                Console.WriteLine($"Расшифрованный текст по биграммам*: {Playfair.ToBigrammString(plainText)}");
                Console.WriteLine();
                Console.WriteLine("*Может присутствовать лишний символ - буква `Ё`");
            }
        }
    }
}

