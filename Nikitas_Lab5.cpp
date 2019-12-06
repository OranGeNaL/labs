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
    bool keyLeft = false;
    bool keyRight = false;
    int leftSonInd;
    int rightSonRight;

    Element()
    {
    }

    Element(int value)
    {
        elValue = value;
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

    while(!file.eof())
    {
        elementMass[k] = *new Element();
        file >> elementMass[k].elValue;
        k++;
    }

    for(int i = 0; i < N; i++)
    {
        cout << elementMass[i].elValue << " ";
    }
    cout << endl;
}