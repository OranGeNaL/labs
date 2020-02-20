#include <iostream>
#include <fstream>
#include <string.h>
#include <string>

class BitVector
{
private:
    unsigned long vector;
    int size;

public:
    BitVector() : vector(0) {}

    BitVector(std::string _U, std::string _set)
    {
        size = _U.length();
        for(int i = 0; i < _set.length(); i++)
        {
            int index = - 1;
            for(int j = 0; j < _U.length(); j++)
            {
                if(_set[i] == _U[j])
                {
                    index = j;
                    break;
                }
            }

            if(index > 0)
            {
                SetBit(index, 1);
            }
        }
    }

    void SetBit(int index, bool value)
    {
        unsigned long tempVector = 1;

        tempVector = tempVector << index;

        if (value == 1)
        {
            vector = vector | tempVector;
        }
        else
        {
            tempVector = ~tempVector;
            vector = vector & tempVector;
        }
    }

    unsigned long GetBit(int index)
    {
        unsigned long tempVector = 1;
        tempVector = tempVector << index;
        tempVector = vector & tempVector;
        tempVector = tempVector >> index;
        return tempVector;
    }

    std::string PrintSet(std::string U)
    {
        
    }
};

int main()
{
    std::ifstream file;
    std::string filePath;
    std::string U = "";
    int readMarker = 0;
    BitVector A, B, C;

    std::string readElement = "";

    std::cout << "Enter file path:";
    std::cin >> filePath;

    file.open(filePath);
    if (!file)
    {
        std::cout << "File is invalid!\n";
        return 1;
    }

    while (true)
    {
        file >> readElement;
        if(readElement == "|")
        {
            readMarker++;
            continue;
        }
        switch (readMarker)
        {
        case 0:
            U = readElement;
            break;
        case 1:
            A = *new BitVector(U, readElement);
            break;
        case 2:
            B = *new BitVector(U, readElement);
            break;
        case 3:
            C = *new BitVector(U, readElement);
            break;
        }


    }
}