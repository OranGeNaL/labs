#include <iostream>
#include <string.h>
#include <string>
#include <fstream>
#include "MyLib.cpp"

using namespace std;

void ShowMatrix(int **, int);

int main()
{
    string inPath;
    int N, matrixSize;
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

    int **mass = new int *[N];
    for (int i = 0; i < N; i++)
        mass[i] = new int[3];

    int k = 0;
    while (!file.eof())
    {
        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < matrixSize; j++)
            {
                int buf;
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

    ShowMatrix(mass, N);
}

void ShowMatrix(int **matrix, int N)
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