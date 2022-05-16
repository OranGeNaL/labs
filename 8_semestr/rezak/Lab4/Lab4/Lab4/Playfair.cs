using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    class Playfair
    {
        private const int Rows = 4;
        private const int Cols = 8;
        private const string Alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        public string execute(string key, string text, bool encode)
        {
            char[,] grid = CreateGrid(key);
            ShowGrid(grid);

            string alteredText = PrepareText(text, encode);
            string bigrammString = ToBigrammString(alteredText);
            Console.WriteLine($"Исходные биграммы: {bigrammString}");

            return InternalExecute(grid, alteredText, encode ? 1 : -1);
        }

        public static string ToBigrammString(string text)
        {
            string bigramms = "";
            for (int i = 0; i < text.Length; i += 2)
            {
                bigramms += $"{text[i].ToString()}{text[i + 1].ToString()} ";
            }

            return bigramms.Trim();
        }

        private static char[,] CreateGrid(string key)
        {
            if (key.Length < 1) key = "КЛЮЧ";
            key += "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЫЬЭЮЯ";
            string newKey = "";

            foreach (char symbol in key)
            {
                char character = Char.ToUpper(symbol);

                if (!Alphabet.Contains(character)) continue;
                if (character.Equals('ъ')) continue;
                if (!newKey.Contains(character)) newKey += character;
            }

            char[,] matrix = new char[Rows, Cols];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    matrix[i, j] = newKey[i * Cols + j];
                }
            }

            return matrix;
        }

        private static void ShowGrid(char[,] grid)
        {
            Console.WriteLine("Матрица");
            Console.WriteLine();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write("{0} ", grid[i, j].ToString());
                }

                Console.WriteLine();
            }
        }


        private static string PrepareText(string text, bool encode)
        {
            string formattedText = "";
            string textForEncoding = "";
            foreach (char symbol in text)
            {
                char character = Char.ToUpper(symbol);

                if (!Alphabet.Contains(character)) continue;
                if (character.Equals('ъ')) character = 'ь';

                formattedText += character;
            }


            if (encode)
            {
                string temp = "";
                for (int i = 0; i < formattedText.Length; i += 2)
                {
                    temp += formattedText[i];

                    if (i + 1 < formattedText.Length)
                    {
                        char newChar = formattedText[i].Equals(formattedText[i + 1]) ? 'Ё' : formattedText[i + 1];
                        temp += newChar;
                    }
                }

                formattedText = temp;
            }

            if (formattedText.Length % 2 != 0)
            {
                formattedText += 'Ё';
            }

            return formattedText;
        }

        private static bool GetCharacterPosition(char[,] grid, char character, ref int a, ref int b)
        {
            for (int y = 0; y < Rows; y++)
                for (int x = 0; x < Cols; x++)
                    if (grid[y, x].Equals(character))
                    {
                        a = x;
                        b = y;
                        return true;
                    }

            return false;
        }

        private static char GetNewCharacter(char[,] grid, int a, int b)
        {
            return grid[(b + Rows) % Rows, (a + Cols) % Cols];
        }


        private static string InternalExecute(char[,] grid, string text, int direction)
        {
            int a = -1, b = -1, c = -1, d = -1;
            string newText = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (GetCharacterPosition(grid, text[i], ref a, ref b))
                {
                    i++;

                    if (GetCharacterPosition(grid, text[i], ref c, ref d))
                    {
                        if (a == c) // Один столбец
                        {
                            newText += GetNewCharacter(grid, a, b + direction);
                            newText += GetNewCharacter(grid, c, d + direction);
                        }
                        else if (b == d) // Одна строка
                        {
                            newText += GetNewCharacter(grid, a + direction, b);
                            newText += GetNewCharacter(grid, c + direction, d);
                        }
                        else
                        {
                            newText += GetNewCharacter(grid, c, b);
                            newText += GetNewCharacter(grid, a, d);
                        }
                    }
                }
            }

            return newText;
        }
    }
}
