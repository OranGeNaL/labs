#include <iostream>
#include <string>

int getNum(char letter) {
    if (letter == ' ') // input with standart spaces
    {
        //std::cout << "Letter \" \": " << 26 << std::endl;
        return 26;
    }
    //std::cout << "Letter \"" << letter << "\": " << letter - 97 << std::endl;
    return letter - 97;
}

char getLetterBase(int num) {
    return num;
}

char getLetter(int num) {
    if (num == 26)
    {
       // std::cout << "Number 26: " << "\"_\"" << std::endl;
        return ' '; // result with space symbol (if have it)
    }
    //std::cout << "Number " << num << ": \"" << getLetterBase(97 + (num % 26)) << "\"" << std::endl;
    return 97 + (num % 26);
}


int vizhiner(int x_i, int k_i) {
    return (x_i + k_i) % 27;
}
int bofort(int x_i, int k_i, int i) {
    int result = 0;
    if ((x_i - k_i) >= 0)
    {
        result = (x_i - k_i) % 26;
        //std::cout << "y" << i << "=" << x_i << " - " << k_i << "(mod 26) = " << result << std::endl;
    }
    else
    {
        result = 27 - ((k_i - x_i) % 26);
        //std::cout << "y" << i << "=" << k_i << " - " << x_i << "(mod 26) = " << result << std::endl;
    }
    //return ((x_i - k_i) >= 0 ? (x_i - k_i) % 26 : 27 - ((k_i - x_i) % 26)); // for circular alphabet
    return result;
}

int main()
{
    int mode(0);
    std::cout << "   Mode:\n";
    std::cout << "1. Enciphering\n";
    std::cout << "2. Deciphering\n";
    std::cin >> mode;

    if (mode != 1 && mode != 2) {
        std::cout << "Exit...\n";
        return EXIT_SUCCESS;
    }
    std::cin.ignore();

    std::string sentence, keyword;
    int type(0);

    std::cout << "Enter sentence: ";
    std::getline(std::cin, sentence); // may be with spaces
    std::cout << "Enter keyword: ";
    std::getline(std::cin, keyword); // may be with spaces

    std::cout << "Enter type:\n";
    std::cout << "1. Vizhiner\n";
    std::cout << "2. Bofort\n";
    std::cin >> type;
    std::cin.ignore();

    if (type != 1 && type != 2) {
        std::cout << "Exit...\n";
        return EXIT_SUCCESS;
    }

    std::string result;
    if (mode == 1) {
        for(int i = 0; i < sentence.size(); ++i)
        {
            if (type == 1) {
                result.push_back(getLetter(vizhiner(getNum(sentence[i]), getNum(keyword[i % keyword.size()]))));
                //std::cout << "y" << i + 1 << "=" << getNum(sentence[i]) << " + " << getNum(keyword[i % keyword.size()]) << "(mod 26) = " << vizhiner(getNum(sentence[i]), getNum(keyword[i % keyword.size()])) << std::endl;
            }
            else {
                result.push_back(getLetter(bofort(getNum(sentence[i]), getNum(keyword[i % keyword.size()]), i + 1)));
            }
        }
    }
    else {
        for (int i = 0; i < sentence.size(); ++i) {
            if (type == 1) {
                result.push_back(getLetter(bofort(getNum(sentence[i]), getNum(keyword[i % keyword.size()]), i + 1)));
            }
            else {
                result.push_back(getLetter(vizhiner(getNum(sentence[i]), getNum(keyword[i % keyword.size()]))));
            }
        }
    }

    std::cout << "  Result: " << result << "\n";

    return EXIT_SUCCESS;
}

