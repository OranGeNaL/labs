#include <iostream>

using namespace std;

int main(int argc, char *argv[])
{
    string res = "";
    for (int i = 1; i < argc; i++)
    {
        res += argv[i];
        res += " ";
    }
    cout << res << "\n";
}