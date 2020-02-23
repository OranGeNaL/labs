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
        for (int i = 0; i < _set.length(); i++)
        {
            int index = -1;
            for (int j = 0; j < _U.length(); j++)
            {
                if (_set[i] == _U[j])
                {
                    index = j;
                    break;
                }
            }

            if (index >= 0)
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

    std::string GetBinary()
    {
        std::string result = "";
        for (int i = 0; i < size; i++)
        {
            result += std::to_string(GetBit(i));
        }
        return result;
    }

    unsigned long GetBit(int index)
    {
        unsigned long tempVector = 1;
        tempVector = tempVector << index;
        tempVector = vector & tempVector;
        tempVector = tempVector >> index;
        return tempVector;
    }

    BitVector Union(BitVector _secondOperand)
    {
        BitVector result;
        result.size = size;
        result.vector = vector | _secondOperand.vector;
        return result;
    }

    BitVector Intersection(BitVector _secondOperand)
    {
        BitVector result;
        result.size = size;
        result.vector = vector & _secondOperand.vector;
        return result;
    }

    BitVector Addition()
    {
        BitVector result;
        result.size = size;
        result.vector = ~vector;
        return result;
    }

    BitVector Substraction(BitVector _secondOperand)
    {
        BitVector result;
        result.size = size;
        result.vector = vector & _secondOperand.Addition().vector;
        return result;
    }

    std::string PrintSet(std::string U)
    {
        std::string result = "";
        for (int i = 0; i < size; i++)
        {
            if (GetBit(i))
            {
                result += U[i];
            }
        }

        return result;
    }
};

int main()
{
    std::ifstream file;
    std::string filePath = "source";
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

    while (readMarker < 4)
    {
        file >> readElement;
        if (readElement == "|")
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

    std::cout << A.PrintSet(U) << "\n"
              << B.PrintSet(U) << "\n"
              << C.PrintSet(U) << std::endl;

    BitVector BnC, AoC, result;
    BnC = B.Intersection(C);
    AoC = A.Union(C).Addition();
    result = AoC.Substraction(BnC);

    std::cout << "Result is: " << result.PrintSet(U) << std::endl;
}