#include <iostream>
#include <string.h>
#include <string>
#include <stdlib.h>
#include <time.h>

using std::cin;
using std::cout;
using std::string;
using std::to_string;

string FileReading(char *, string); //Получает из файла исходный текст
string PreEncoder(string); //Запускает все функции, подготавливающие к кодированию
string Encoder(string, int *, int *, int); //Кодирует исходный текст с помощью ключей
string LengthFixer(string, int *); //Дополняет исходный текст пробелами до нужной длины
string KeyWriter(int *, int); //Добавляет второй ключ к строке результата
void FileCreating(char *, string); //Функция создает файл и записывает в него результат
bool Checker(int *, int, int); //Проверяет сгенерированное число на присутствие во втором ключе
void KeyGenerator(int *, int); //Генерирует второй ключ

int main()
{

    char im_path[50];
    char ex_path[50];
    string text;

    cout << "Введите путь к исходному файлу: ";
    cin >> im_path;
    cout << "Введите имя выходного файла: ";
    cin >> ex_path;

    text = FileReading(im_path, text);

    text = PreEncoder(text);

    FileCreating(ex_path, text);
}

string PreEncoder(string text)
{
    int m = 0;

    text = LengthFixer(text, &m);
    int first_key[] = {4, 6, 5, 3, 1, 2};
    int *second_key = new int[m];
    KeyGenerator(second_key, m);

    text = Encoder(text, first_key, second_key, m);

    text += KeyWriter(second_key, m);
    return text;
}

string Encoder(string text, int *first_key, int *second_key, int m)
{
    string encoded_text;
    string calc[6];
    for(int i = 0; i < 6; i++)
    {
        calc[first_key[i] - 1] = text.substr(i*m, m);
    }

    for(int i = 0; i < 6; i++)
        cout << calc[i] << "\n";
    for(int i = 0; i < m; i++)
    {
        string temp;
        for(int j = 0; j < 6; j++)
        {
            temp += calc[j][second_key[i] - 1];
        }
        encoded_text += temp;
    }

    return encoded_text;
}

string LengthFixer(string text, int *m)
{
    int delta = (text.length() - 1) % 6;
    if (delta > 0)
    {
        delta = 6 - delta;
        for (int i = 0; i < delta; i++)
        {
            text.insert(text.length() - 1, " ");
        }
    }
    *m = text.length() / 6;
    return text;
}

void KeyGenerator(int *key, int m)
{
    srand(time(0));
    for (int i = 0; i < m; i++)
    {
        while (true)
        {
            int b = rand() % m + 1;

            if (Checker(key, m, b))
            {
                key[i] = b;
                break;
            }
        }
    }
}

string KeyWriter(int *key, int m)
{
    string str_key = "[\n";
    for (int i = 0; i < m; i++)
    {
        str_key += to_string(key[i]);
        if(i != m - 1)
        {
            str_key += " ";
        }
    }
    
    return str_key;
}

bool Checker(int *key, int m, int b)
{
    bool check = true;

    for (int j = 0; j < m; j++)
    {
        if (b == key[j])
        {
            check = false;
        }
    }
    return check;
}

string FileReading(char *name, string text)
{
    FILE *origin;
    origin = fopen(name, "r");
    if (origin != NULL)
    {
        char buf[1000];
        while ((fgets(buf, 1000, origin)) != NULL)
        {
            text.insert(text.length(), buf);
        }
        fclose(origin);
    }
    else
    {
        printf("Такого файла не существует\n");
    }

    return text;
}

void FileCreating(char *qway, string fintext)
{
    FILE *qfile;
    qfile = fopen(qway, "w");
    fputs(fintext.c_str(), qfile);
    fclose(qfile);
}