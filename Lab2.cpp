#include <iostream>
#include <string.h>
#include <string>

using namespace std;

string LengthFixer(string);
long long int Converting(string);
long long Exponentiation(int);

int main()
{
    string inputData;

    cout << "Введите двоичное число: ";
    cin >> inputData;

    inputData = LengthFixer(inputData);

    if (inputData == "err")
    {
        cout << "Введено неверное число\n";
    }
    else
    {
        cout << inputData << endl;
    }

    long long int num = Converting(inputData);
    cout << num << endl;
}

string LengthFixer(string data)
{
    for (int i = 0; i < data.length(); i++)
    {
        if (data[i] != '1' && data[i] != '0')
            return "err";
    }

    while (true)
    {
        if (data.length() == 1 && data[0] == '0')
        {
            return "err";
        }
        else if (data[0] == '1')
        {
            return data;
        }
        else if (data[0] == '0')
        {
            data.erase(0, 1);
        }
    }

    return data;
}

long long int Converting(string data)
{
    long long num = 0;

    for (int i = data.length() - 1; i >= 0; i--)
    {
        long long a = (int)data[data.length() - 1 - i] - 48;
        a = a * Exponentiation(i);
        cout << a << endl;
        cout << "2^" << i << " " << a << endl;
        num += a;
    }

    return num;
}

long long Exponentiation(int i)
{
    long long a = 2;
    if (i > 1)
    {
        for (int k = 2; k <= i; k++)
        {
            a = a * 2;
        }
        return a;
    }
    else if(i == 1)
    {
        return 2;
    }
    else if(i == 0)
    {
        return 1;
    }
    return 0;
}