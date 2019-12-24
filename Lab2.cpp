#include <iostream>
#include <string.h>
#include <string>
#define MASS_LENGTH 1000

using namespace std;

struct Number
{
public:
    int mass[MASS_LENGTH];

    Number()
    {
        for (int i = 0; i < MASS_LENGTH; i++)
        {
            mass[i] = 0;
        }
    }

    void Addition(Number secondOperand)
    {
        int excess = 0;
        for (int i = MASS_LENGTH - 1; i >= 0; i--)
        {
            mass[i] += excess;
            mass[i] += secondOperand.mass[i];
            if (mass[i] > 9)
            {
                mass[i] -= 10;
                excess = 1;
            }
            else
            {
                excess = 0;
            }
        }
    }

    void Multiplication(int value)
    {
        int excess = 0;
        for (int i = MASS_LENGTH - 1; i >= 0; i--)
        {
            mass[i] = mass[i] * value;
            mass[i] += excess;
            excess = 0;
            if (mass[i] > 9)
            {
                while (mass[i] > 9)
                {
                    mass[i] -= 10;
                    excess += 1;
                }
            }
            else
            {
                excess = 0;
            }
        }
    }

    void Equating(int value)
    {
        Clearing();
        string valueInStr = to_string(value);
        for (int i = valueInStr.length(); i >= 0; i--)
        {
            mass[MASS_LENGTH - i] = valueInStr[valueInStr.length() - i] - '0';
        }
    }

    void Clearing()
    {
        for (int i = 0; i < MASS_LENGTH; i++)
        {
            mass[i] = 0;
        }
    }

    string PrintValue()
    {
        bool isBegan = false;
        string thisNumInStr = "";
        for (int i = 0; i < MASS_LENGTH; i++)
        {
            if (isBegan)
            {
                thisNumInStr += to_string(mass[i]);
                continue;
            }
            if (!isBegan && mass[i] != 0)
            {
                isBegan = true;
                thisNumInStr += to_string(mass[i]);
            }
        }

        return thisNumInStr;
    }

private:
};

string LengthFixer(string);
Number Converting(string);

int main()
{
    string inputData;

    cout << "Введите двоичное число: ";
    cin >> inputData;

    inputData = LengthFixer(inputData);

    Number totalValue = *new Number();
    // Number secondNumber = *new Number();

    //  number.Equating(25);
    //  cout << number.PrintValue() << endl;

    //  number.Multiplication(5);
    //  cout << number.PrintValue() << endl;

    // secondNumber.Equating(196);
    // cout << secondNumber.PrintValue() << endl;

    // number.Addition(secondNumber);
    // cout << number.PrintValue() << endl;

    if (inputData == "err")
    {
        cout << "Введено неверное число\n";
        return 0;
    }
    
    totalValue = Converting(inputData);

    cout << "Total value is: " << totalValue.PrintValue() << endl;

    return 0;
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

Number Converting(string data)
{
    Number number = *new Number();

    for (int i = data.length(); i > 0; i--)
    {
        if (data[data.length() - i] != '0')
        {
            Number coefficient = *new Number();
            coefficient.Equating(1);
            if(data.length() - i != data.length())
            {
                for(int j = 1; j <= i - 1; j++)
                {
                    coefficient.Multiplication(2);
                }
            }
            number.Addition(coefficient);
        }
    }

    return number;
}
