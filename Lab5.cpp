#include <iostream>
#include <string.h>
#include <string>
#include <fstream>
#include <math.h>
#include "MyLib.cpp"

using namespace std;

struct TreeElement
{
public:
    TreeElement *rightBrother;
    TreeElement *leftChild;
    int treeSize = 0;

    TreeElement(int level = 0)
    {
        int enteredValue;
        int switcher;
        bool hasAChild = true;
        bool hasABrother = true;
        elementLevel = level;
        cout << "Enter element value: ";
        cin >> enteredValue;
        elementValue = enteredValue;
        cout << "Does element with level " << elementLevel << " and value " << elementValue << " has a child?\n"
             << "1.Yes\n"
             << "2.No\n";
        while (hasAChild)
        {
            cout << "Enter a command name: ";
            cin >> switcher;
            switch (switcher)
            {
            case 1:
                leftChild = new TreeElement(elementLevel + 1);
                hasAChild = false;
                break;
            case 2:
                hasAChild = false;
                break;
            default:
                cout << "Wrong command number!\n";
                break;
            }
        }
        cout << "Does element with level " << elementLevel << " and value " << elementValue << " has a brother?\n"
             << "1.Yes\n"
             << "2.No\n";
        while (hasABrother)
        {
            cout << "Enter a command name: ";
            cin >> switcher;
            switch (switcher)
            {
            case 1:
                rightBrother = new TreeElement(elementLevel);
                hasABrother = false;
                break;
            case 2:
                hasABrother = false;
                break;
            default:
                cout << "Wrong command number!\n";
                break;
            }
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
    TreeElement root = *new TreeElement();
    int switcher;
    int enteredValue;
    int treeSize = 0;

    while (true)
    {
        cout << "Choose the command\n"
             << "1.Show a tree\n"
             << "2.Show a tree with specified heigth\n"
             << "3.Exit\n";
        cout << "Enter a command number: ";
        cin >> switcher;
        switch (switcher)
        {
        case 1:
            root.ShowTree();
            break;
        case 2:
            cout << "Enter tree size: ";
            cin >> enteredValue;
            enteredValue--;
            if (enteredValue <= root.TreeSize(&treeSize, &root))
            {
                root.ShowTree(enteredValue);
            }
            else
            {
                cout << "Invalid value!\n";
            }
            break;
        case 3:
            return 0;
            break;
        default:
            cout << "Wrong command number!\n";
            break;
        }
    }
}