#include <iostream>
#include <string.h>
#include <string>
#include <stdio.h>

using namespace std;

struct Ticket
{
    int rowNum = -1;
    int placeNum = -1;
    string secondName = "";
    int nextInd = -2;
};

const int maxRow = 12;
const int maxPlace = 30;
int head = -1;
int length = 0;

bool AviabilityChecker(Ticket *, int, int);
void AddElement(Ticket *);
void RemoveElement(Ticket *, int);
void List(Ticket *);
void Search(Ticket *, int, int);
void Search(Ticket *, string);
void Edit(Ticket *, int);
void PlacesInARow(Ticket *, int);
void ConsoleCleaner();
int EmptySpaceFinder(Ticket *);
int NumGetter();

int main()
{
    Ticket myList[100];
    printf("Welcome to the ticket base system\n");

    while (true)
    {
        int tempRow, tempPlace;
        string tempSecondName;
        printf("Please choose an action:\n");
        printf("1.Add a ticket\n");
        printf("2.Remove a ticket\n");
        printf("3.List\n");
        printf("4.Find by Row and Place\n");
        printf("5.Find by second name\n");
        printf("6.Edit ticket\n");
        printf("7.Empty places in a row\n");
        printf("8.Exit\n");
        printf("Enter a command number: ");
        int x;
        cin >> x;
        switch (x)
        {
        case 1:
            AddElement(myList);
            break;
        case 2:
            int k;
            printf("Enter ticket's number: ");
            k = NumGetter();
            if (k > 0 && k <= length)
            {
                RemoveElement(myList, k);
            }
            else
            {
                ConsoleCleaner();
                printf("Number must be in length range!\n");
            }
            break;
        case 3:
            ConsoleCleaner();
            List(myList);
            break;
        case 4:
            cout << "Enter row number: ";
            tempRow = NumGetter();
            cout << "Enter place number: ";
            tempPlace = NumGetter();
            if (tempRow >= 1 && tempRow <= maxRow && tempPlace >= 1 && tempPlace <= maxPlace)
                Search(myList, tempRow, tempPlace);
            break;
        case 5:
            cout << "Enter second name: ";
            cin >> tempSecondName;
            Search(myList, tempSecondName);
            break;
        case 6:
            cout << "Enter ticket number: ";
            tempRow = NumGetter();
            if (tempRow >= 1 && tempRow <= length)
            {
                Edit(myList, tempRow);
            }
            else
            {
                ConsoleCleaner();
                printf("Enter a valid ticket number!\n");
            }
            break;
        case 7:
            cout << "Enter row number: ";
            tempRow = NumGetter();
            if (tempRow >= 1 && tempRow <= maxRow)
                PlacesInARow(myList, tempRow);
            else
                printf("Enter a valid row number!\n");
            break;
        case 8:
            return 0;
        default:
            printf("Enter a valid command number!\n");
            break;
        }
    }
}

void AddElement(Ticket *list)
{
    printf("\n----------------------------------------------------------------------------------\n");
    int ind = EmptySpaceFinder(list);
    int x;
    int tempRowNum;
    int tempPlaceNum;
    string tempSecondName;

    printf("1.This is a purchase\n");
    printf("2.This is a reservation\n");
    printf("Enter a command numder: ");
    cin >> x;
    switch (x)
    {
    case 1:
        printf("Enter a row number: ");
        while (true)
        {
            tempRowNum = NumGetter();
            if (tempRowNum <= maxRow && tempRowNum >= 1)
            {
                break;
            }
        }
        printf("Enter a place number: ");
        while (true)
        {
            tempPlaceNum = NumGetter();
            if (tempPlaceNum <= maxPlace && tempPlaceNum >= 1)
            {
                break;
            }
        }
        if (AviabilityChecker(list, tempRowNum, tempPlaceNum))
        {
            list[ind].nextInd = head;
            head = ind;
            list[ind].placeNum = tempPlaceNum;
            list[ind].rowNum = tempRowNum;
            length += 1;
            ConsoleCleaner();
        }
        else
        {
            ConsoleCleaner();
            cout << "This place isn't available";
            printf("\n----------------------------------------------------------------------------------\n");
        }
        break;
    case 2:
        printf("Enter a row number: ");
        while (true)
        {
            tempRowNum = NumGetter();
            if (tempRowNum <= maxRow && tempRowNum >= 1)
            {
                break;
            }
        }
        printf("Enter a place number: ");
        while (true)
        {
            tempPlaceNum = NumGetter();
            if (tempPlaceNum <= maxPlace && tempPlaceNum >= 1)
            {
                break;
            }
        }
        printf("Enter your second name: ");
        cin >> tempSecondName;
        if (AviabilityChecker(list, tempRowNum, tempPlaceNum))
        {
            list[ind].nextInd = head;
            list[ind].placeNum = tempPlaceNum;
            list[ind].rowNum = tempRowNum;
            list[ind].secondName = tempSecondName;
            head = ind;
            length += 1;
            ConsoleCleaner();
        }
        else
        {
            ConsoleCleaner();
            cout << "This place isn't available";
            printf("\n----------------------------------------------------------------------------------\n");
        }
        break;

    default:
        ConsoleCleaner();
        printf("Enter a valid command name!\n");
        break;
    }
}

void RemoveElement(Ticket *list, int ind)
{
    int cur = head;
    int prev = head;
    if (ind != 1)
    {
        for (int i = 1; i < ind; i++)
        {
            cur = list[cur].nextInd;
        }

        for (int i = 1; i < ind - 1; i++)
        {
            prev = list[prev].nextInd;
        }
        list[prev].nextInd = list[cur].nextInd;
        list[cur].nextInd = -2;
        list[cur].placeNum = -1;
        list[cur].rowNum = -1;
        list[cur].secondName = "";
    }
    if (ind == 1)
    {
        head = list[cur].nextInd;
        list[cur].nextInd = -2;
        list[cur].placeNum = -1;
        list[cur].rowNum = -1;
        list[cur].secondName = "";
    }
    length--;
    ConsoleCleaner();
    cout << "Ticket with " << ind << " number was deleted!";
    printf("\n----------------------------------------------------------------------------------\n");
    return;
}

void Edit(Ticket *list, int ind)
{
    int cur = head;
    int tempRow, tempPlace;
    string tempSecondName = "";
    cout << "Enter row number: ";
    tempRow = NumGetter();
    cout << "Enter place number: ";
    tempPlace = NumGetter();
    if (tempRow >= 1 && tempRow <= maxRow && tempPlace >= 1 && tempPlace <= maxPlace)
    {
        if (AviabilityChecker(list, tempRow, tempPlace))
        {
            if (ind != 1)
            {
                for (int i = 1; i < ind; i++)
                {
                    cur = list[cur].nextInd;
                }
                list[cur].placeNum = tempPlace;
                list[cur].rowNum = tempRow;
                list[cur].secondName = tempSecondName;
            }
            if (ind == 1)
            {
                if (list[cur].secondName != "")
                {
                    cout << "Enter second name: ";
                    cin >> tempSecondName;
                }
                list[cur].placeNum = tempPlace;
                list[cur].rowNum = tempRow;
                list[cur].secondName = tempSecondName;
            }
            ConsoleCleaner();
        }
        else
        {
            ConsoleCleaner();
            cout << "This place isn't available";
            printf("\n----------------------------------------------------------------------------------\n");
        }
    }
    else
    {
        ConsoleCleaner();
        cout << "Enter valid numbers!";
        printf("\n----------------------------------------------------------------------------------\n");
    }
}

void Search(Ticket *list, int rowNum, int placeNum)
{
    bool checker = false;
    if (head != -1)
    {
        int ind = head;
        int i = 1;
        while (true)
        {
            if (list[ind].rowNum == rowNum && list[ind].placeNum == placeNum)
            {
                checker = true;
                break;
            }
            if (list[ind].nextInd == -1)
            {
                break;
            }
            else
            {
                ind = list[ind].nextInd;
                i++;
            }
        }
        if (checker)
        {
            ConsoleCleaner();
            cout << "Ticket was found!\n";
            cout << "Order: " << i;
            cout << "\nRow: " << list[ind].rowNum;
            cout << "\nPlace: " << list[ind].placeNum;
            cout << "\nOwner: " << list[ind].secondName;
            cout << "\nNext element ind: " << list[ind].nextInd;
            printf("\n----------------------------------------------------------------------------------\n");
        }
        if (!checker)
        {
            ConsoleCleaner();
            cout << "Such a ticket wasn't found!";
            printf("\n----------------------------------------------------------------------------------\n");
        }
    }
}

void Search(Ticket *list, string secondName)
{
    ConsoleCleaner();
    bool checker = false;
    if (head != -1)
    {
        int ind = head;
        int i = 1;
        while (true)
        {
            if (list[ind].secondName == secondName)
            {
                cout << "Ticket was found!\n";
                cout << "Order: " << i;
                cout << "\nRow: " << list[ind].rowNum;
                cout << "\nPlace: " << list[ind].placeNum;
                cout << "\nOwner: " << list[ind].secondName;
                cout << "\nNext element ind: " << list[ind].nextInd;
                printf("\n----------------------------------------------------------------------------------\n");
                checker = true;
            }
            if (list[ind].nextInd == -1)
            {
                break;
            }
            else
            {
                ind = list[ind].nextInd;
                i++;
            }
        }
        if (!checker)
        {
            ConsoleCleaner();
            cout << "Such a ticket wasn't found!";
            printf("\n----------------------------------------------------------------------------------\n");
        }
    }
}

void PlacesInARow(Ticket *list, int rowNum)
{
    int remainingSeats = maxPlace;
    if (head != -1)
    {
        int ind = head;
        while (true)
        {
            if (list[ind].rowNum == rowNum)
            {
                remainingSeats--;
            }
            if (list[ind].nextInd == -1)
            {
                break;
            }
            else
            {
                ind = list[ind].nextInd;
            }
        }
    }
    ConsoleCleaner();
    cout << remainingSeats << " places available in " << rowNum << " row";
    printf("\n----------------------------------------------------------------------------------\n");
}

int EmptySpaceFinder(Ticket *list)
{
    for (int i = 0; i < 100; i++)
    {
        if (list[i].placeNum == -1 && list[i].rowNum == -1)
        {
            //cout << "Empty is: " << i << endl;
            return i;
        }
    }
    return -1;
}

bool AviabilityChecker(Ticket *list, int rowNum, int placeNum)
{
    if (head != -1)
    {
        int ind = head;
        while (true)
        {
            if (list[ind].rowNum == rowNum && list[ind].placeNum == placeNum)
                return false;
            if (list[ind].nextInd == -1)
                break;
            else
                ind = list[ind].nextInd;
        }
    }
    return true;
}

int NumGetter()
{
    int x = -1;
    string xStr;
    while (true)
    {
        cin >> xStr;
        try
        {
            x = atoi(xStr.c_str());
        }
        catch (const std::exception &e)
        {
            std::cerr << e.what() << '\n';
        }
        if (x != -1 && x != 0)
            return x;
    }
}

void List(Ticket *list)
{
    if (head != -1)
    {
        int ind = head;
        int i = 1;
        while (true)
        {
            cout << "Order: " << i;
            cout << "\nRow: " << list[ind].rowNum;
            cout << "\nPlace: " << list[ind].placeNum;
            cout << "\nOwner: " << list[ind].secondName;
            cout << "\nNext element ind: " << list[ind].nextInd;
            printf("\n----------------------------------------------------------------------------------\n");
            ind = list[ind].nextInd;
            i++;
            if (ind == -1)
            {
                break;
            }
        }
        cout << "Length: " << length;
        printf("\n----------------------------------------------------------------------------------\n");
    }
}

void ConsoleCleaner()
{
    printf("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
}