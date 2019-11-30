#include <iostream>
#include <string.h>
#include <string>
#include <fstream>
#include "MyLib.cpp"

using namespace std;

void ShowInternalMatrix(float **, int);
void ShowExternalMatrix(float **, int, int);

int main()
{
    string inPath;
    int N, matrixSize, lineSum, lineNumber, finalMatrixLineNumber;
    bool diaIsntAZero = false;
    lineSum = 0;

    cout << "Input file mist be like:\n"
         << "not_zero_elements source_matrix_size\n"
         << "element element element\n";
    cout << "Enter file path: ";
    cin >> inPath;

    ifstream file;
    file.open(inPath);
    if (!file)
    {
        cout << "File is invalid!\n";
        return 1;
    }

    file >> N;
    file >> matrixSize;

    float **mass = new float *[N];
    for (int i = 0; i < N; i++)
        mass[i] = new float[3];

    int k = 0;
    while (!file.eof())
    {
        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < matrixSize; j++)
            {
                float buf;
                file >> buf;
                if (buf != 0)
                {
                    mass[k][0] = i;
                    mass[k][1] = j;
                    mass[k][2] = buf;
                    k++;
                }
            }
        }
    }

    ShowExternalMatrix(mass, N, matrixSize);

    cout << "Enter line number: ";
    while (true)
    {
        cin >> lineNumber;
        if (lineNumber > 0 && lineNumber <= matrixSize)
            break;
        else
            printf("Enter a valid number!\n");
    }

    for (int i = 0; i < N; i++)
    {
        if (mass[i][0] == mass[i][1] && mass[i][1] == lineNumber - 1)
        {
            printf("It just works!\n");
            finalMatrixLineNumber = i;
            diaIsntAZero = true;
            break;
        }
    }

    if (diaIsntAZero)
    {
        for (int i = 0; i < N; i++)
        {
            if (mass[i][0] == lineNumber - 1 && mass[i][0] != mass[i][1])
            {
                mass[i][2] = mass[i][2] / mass[finalMatrixLineNumber][2];
            }
        }
        ShowExternalMatrix(mass, N, matrixSize);
    }

    else if (!diaIsntAZero)
    {
        for (int i = 0; i < N; i++)
        {
            if (mass[i][0] == lineNumber - 1)
            {
                lineSum += mass[i][2];
            }
        }

        cout << "Line summ: " << lineSum << endl;
    }

    //ShowInternalMatrix(mass, N);
}

void ShowInternalMatrix(float **matrix, int N)
{
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            cout << matrix[i][j] << " ";
        }
        cout << endl;
    }
}

void ShowExternalMatrix(float **mass, int N, int matrixSize)
{
    for (int i = 0; i < matrixSize; i++)
    {
        for (int j = 0; j < matrixSize; j++)
        {
            bool isntAZero = false;
            int internalIndex = 0;
            for (int k = 0; k < N; k++)
            {
                if (mass[k][0] == i && mass[k][1] == j)
                {
                    isntAZero = true;
                    internalIndex = k;

                    break;
                }
            }
            if (isntAZero)
            {
                cout << mass[internalIndex][2] << " ";
            }
            else
            {
                cout << 0 << " ";
            }
        }
        cout << endl;
    }
}