#include <iostream>
#include <string.h>
#include <string>
#include <fstream>
#include <math.h>
#include <stdlib.h>

using namespace std;

struct Element
{
public:
    int elValue;
    // bool keyLeft = false;
    // bool keyRight = false;
    int leftSonInd = 0;
    int rightSonInd = 0;

    Element()
    {
    }

    Element(int value)
    {
        elValue = value;
    }

    bool Building(Element *mass, int ind, int value)
    {
        if (value < elValue)
        {
            if (!leftSonInd)
            {
                leftSonInd = ind;
            }
            else
            {
                mass[leftSonInd].Building(mass, ind, value);
            }
        }
        else
        {
            if (!rightSonInd)
            {
                rightSonInd = ind;
            }
            else
            {
                mass[rightSonInd].Building(mass, ind, value);
            }
        }
    }

private:
};

// struct List
// {
// public:
//     List *nextListEl;
//     Element *element;
//     List()
//     {

//     }
//     List(int value)
//     {
//         element = new Element(value);
//     }

// private:
// };

int main()
{
    int N;
    int k = 0;
    string inputPath;
    cout << "Enter input file path: ";
    cin >> inputPath;
    ifstream file;
    file.open(inputPath);

    if (!file)
    {
        cout << "File is invalid!\n";
        return 1;
    }

    file >> N;

    Element *elementMass = new Element[N];

    for (int i = 0; i < N; i++)
    {
        elementMass[i] = *new Element();
    }

    while (!file.eof())
    {
        file >> elementMass[k].elValue;
        k++;
    }

    for (int i = 0; i < N; i++)
    {
        cout << elementMass[i].elValue << " ";
    }
    cout << endl;

    for (int i = 1; i < N; i++)
    {
        elementMass[0].Building(elementMass, i, elementMass[i].elValue);
    }

    for (int i = 0; i < N; i++)
    {
        if (!elementMass[i].leftSonInd)
        {
            cout << "Element's " << elementMass[i].elValue << " right child: " << elementMass[elementMass[i].leftSonInd].elValue;
        }
        else if (!elementMass[i].rightSonInd)
        {
            cout << "Element's " << elementMass[i].elValue << " left child: " << elementMass[elementMass[i].rightSonInd].elValue;
        }
        else if (!elementMass[i].rightSonInd && !elementMass[i].leftSonInd)
        {
            cout << "Element " << elementMass[i].elValue << " hasn't any child";
        }
        else
        {
            cout << "Element's " << elementMass[i].elValue << " children: " << elementMass[elementMass[i].leftSonInd].elValue << " and " << elementMass[elementMass[i].rightSonInd].elValue;
        }
        cout << endl;
    }
}