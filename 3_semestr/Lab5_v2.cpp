#include <iostream>
#include <string.h>
#include <string>
#include <fstream>
#include <math.h>
#include <stdlib.h>
#include <time.h>
#include "MyLib.cpp"

using namespace std;

struct TreeElement
{
public:
    TreeElement *rightBrother;
    TreeElement *leftChild;
    int treeSize = 0;

    TreeElement(int treeHigh, bool isABrother = false, int level = 0)
    {
        // cout << level << " ";
        elementValue = rand() % 300;
        elementLevel = level;
        bool hasAChild = true;
        bool hasABrother = !isABrother;
        if (elementLevel == 0)
        {
            hasABrother = false;
        }
        if (treeHigh - elementLevel > 0)
        {
            leftChild = new TreeElement(treeHigh, false, elementLevel + 1);
        }
        if (hasABrother)
        {
            rightBrother = new TreeElement(treeHigh, true, elementLevel);
        }
    }

    void ShowTree()
    {
        string substring = ">";
        if (elementLevel != 0)
        {
            substring.insert(0, " ");
        }
        for (int i = 1; i < elementLevel; i++)
        {
            substring.insert(1, "| ");
        }
        if (elementLevel != 0 && rightBrother)
        {
            substring.insert(substring.length() - 1, "+");
        }
        if (elementLevel != 0 && !rightBrother)
        {
            substring.insert(substring.length() - 1, "L");
        }
        cout << substring << elementValue << endl;
        if (leftChild)
            leftChild->ShowTree();
        if (rightBrother)
            rightBrother->ShowTree();
    }

    void ShowTree(int length)
    {
        if (elementLevel <= length)
        {
            string substring = ">";
            if (elementLevel != 0)
            {
                substring.insert(0, " ");
            }
            for (int i = 1; i < elementLevel; i++)
            {
                substring.insert(1, "| ");
            }
            if (elementLevel != 0 && rightBrother)
            {
                substring.insert(substring.length() - 1, "+");
            }
            if (elementLevel != 0 && !rightBrother)
            {
                substring.insert(substring.length() - 1, "L");
            }
            cout << substring << elementValue << endl;
            if (leftChild)
                leftChild->ShowTree(length);
            if (rightBrother)
                rightBrother->ShowTree(length);
        }
    }

    int TreeSize(int *size, TreeElement *root)
    {
        if (leftChild)
        {
            leftChild->TreeSize(size, root);
        }
        if (rightBrother)
        {
            rightBrother->TreeSize(size, root);
        }
        if (elementLevel > *size)
        {
            *size = elementLevel;
        }
    }

private:
    int elementValue;
    int elementLevel;
};

int main()
{
    srand(time(0));
    int switcher;
    int enteredValue;
    cout << "Enter a tree high: ";
    cin >> enteredValue;
    TreeElement root = *new TreeElement(enteredValue - 1);

    while (true)
    {
        cout << "Choose the command\n"
             << "1.Show a tree\n"
             << "2.Exit\n";
        cout << "Enter a command number: ";
        cin >> switcher;
        switch (switcher)
        {
        case 1:
            root.ShowTree();
            break;
        case 2:
            return 0;
            break;
        default:
            cout << "Wrong command number!\n";
            break;
        }
    }
}