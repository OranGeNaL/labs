#include <iostream>
#include <string.h>
#include <string>
#include <stdio.h>

using namespace std;

struct Ticket
{
    int rowNum = -1;
    int placeNum = -1;
    int nextInd = -2;
};

struct Order
{
    int rowNum = -1;
    int placeNum = -1;
    string secondName = "";
    int nextInd = -2;
};

const int maxRow = 12;
const int maxPlace = 30;
int ticketHead = -1;
int orderHead = -1;
int ticketLength = 0;
int orderLength = 0;

bool AviabilityChecker(Ticket *, Order *, int, int);
void AddElement(Ticket *, Order *);
void AddElement(Order *, Ticket *);
void RemoveElement(Ticket *, int);
void RemoveElement(Order *, int);
void List(Ticket *, Order *);
void Search(Ticket *, Order *, int, int);
void Search(Order *, string);
void Edit(Ticket *, Order *, int);
void Edit(Order *, Ticket *, int);
void PlacesInARow(Ticket *, Order *, int);
void ConsoleCleaner();
int EmptySpaceFinder(Ticket *);
int EmptySpaceFinder(Order *);
int NumGetter();

int main() //TODO:Order->Ticket
{
    Ticket myList[100];
    Order orderList[100];
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
        printf("8.Move order to purchace\n");
        printf("9.Exit\n");
        printf("Enter a command number: ");
        int x;
        int k;
        cin >> x;
        switch (x)
        {
        case 1:
            printf("\n----------------------------------------------------------------------------------\n");
            cout << "1.Add a purchace\n";
            cout << "2.Add an order\n";
            cout << "Enter a command number: ";
            cin >> x;
            switch (x)
            {
            case 1:
                AddElement(myList, orderList);
                break;
            case 2:
                AddElement(orderList, myList);
                break;
            default:
                ConsoleCleaner();
                printf("Enter a valid command number!\n");
                printf("\n----------------------------------------------------------------------------------\n");
                break;
            }
            break;
        case 2:
            ConsoleCleaner();
            printf("\n----------------------------------------------------------------------------------\n");
            printf("Removing\n");
            printf("Enter ticket's number: ");
            k = NumGetter();
            cout << "1.Remove a purchace\n";
            cout << "2.Remove an order\n";
            cout << "Enter a command number: ";
            cin >> x;
            switch (x)
            {
            case 1:
                if (k > 0 && k <= ticketLength)
                {
                    RemoveElement(myList, k);
                }
                else
                {
                    ConsoleCleaner();
                    printf("Number must be in length range!\n");
                }
                break;
            case 2:
                if (k > 0 && k <= orderLength)
                {
                    RemoveElement(orderList, k);
                }
                else
                {
                    ConsoleCleaner();
                    printf("Number must be in length range!\n");
                }
                break;
            default:
                ConsoleCleaner();
                printf("Enter a valid command number!\n");
                printf("\n----------------------------------------------------------------------------------\n");
                break;
            }

            break;
        case 3:
            ConsoleCleaner();
            List(myList, orderList);
            break;
        case 4:
            ConsoleCleaner();
            printf("\n----------------------------------------------------------------------------------\n");
            cout << "Enter row number: ";
            tempRow = NumGetter();
            cout << "Enter place number: ";
            tempPlace = NumGetter();
            if (tempRow >= 1 && tempRow <= maxRow && tempPlace >= 1 && tempPlace <= maxPlace)
                Search(myList, orderList, tempRow, tempPlace);
            else
            {
                ConsoleCleaner();
                printf("Enter a valid numbers!");
                printf("\n----------------------------------------------------------------------------------\n");
            }
            break;
        case 5:
            ConsoleCleaner();
            printf("\n----------------------------------------------------------------------------------\n");
            cout << "Enter second name: ";
            cin >> tempSecondName;
            Search(orderList, tempSecondName);
            break;
        case 6:
            ConsoleCleaner();
            printf("\n----------------------------------------------------------------------------------\n");
            printf("Editing\n");
            printf("Enter ticket's number: ");
            k = NumGetter();
            cout << "1.Edit a purchace\n";
            cout << "2.Edit an order\n";
            cout << "Enter a command number: ";
            cin >> x;
            switch (x)
            {
            case 1:
                if (k >= 1 && k <= ticketLength)
                {
                    Edit(myList, orderList, k);
                }
                else
                {
                    ConsoleCleaner();
                    printf("Enter a valid ticket number!\n");
                }
                break;
            case 2:
                if (k >= 1 && k <= orderLength)
                {
                    Edit(orderList, myList, k);
                }
                else
                {
                    ConsoleCleaner();
                    printf("Enter a valid ticket number!\n");
                }
                break;
            }

            break;
        case 7:
            cout << "Enter row number: ";
            tempRow = NumGetter();
            if (tempRow >= 1 && tempRow <= maxRow)
                PlacesInARow(myList, orderList, tempRow);
            else
                printf("Enter a valid row number!\n");
            break;
        case 8://TODO:
            break;
        case 9:
            return 0;
        default:
            printf("Enter a valid command number!\n");
            break;
        }
    }
}

void AddElement(Ticket *list, Order *orderList) //For purchaces
{
    printf("\n----------------------------------------------------------------------------------\n");
    int ind = EmptySpaceFinder(list);
    int tempRowNum;
    int tempPlaceNum;
    string tempSecondName;

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
    if (AviabilityChecker(list, orderList, tempRowNum, tempPlaceNum))
    {
        list[ind].nextInd = ticketHead;
        ticketHead = ind;
        list[ind].placeNum = tempPlaceNum;
        list[ind].rowNum = tempRowNum;
        ticketLength += 1;
        ConsoleCleaner();
    }
    else
    {
        ConsoleCleaner();
        cout << "This place isn't available";
        printf("\n----------------------------------------------------------------------------------\n");
    }
}

void AddElement(Order *list, Ticket *ticketList) //For orders
{
    printf("\n----------------------------------------------------------------------------------\n");
    int ind = EmptySpaceFinder(list);
    int tempRowNum;
    int tempPlaceNum;
    string tempSecondName;

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
    printf("Enter a second name: ");
    cin >> tempSecondName;
    if (AviabilityChecker(ticketList, list, tempRowNum, tempPlaceNum))
    {
        list[ind].nextInd = orderHead;
        orderHead = ind;
        list[ind].placeNum = tempPlaceNum;
        list[ind].rowNum = tempRowNum;
        list[ind].secondName = tempSecondName;
        orderLength += 1;
        ConsoleCleaner();
    }
    else
    {
        ConsoleCleaner();
        cout << "This place isn't available";
        printf("\n----------------------------------------------------------------------------------\n");
    }
}

void RemoveElement(Ticket *list, int ind) //For purchaces
{
    int cur = ticketHead;
    int prev = ticketHead;
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
    }
    if (ind == 1)
    {
        ticketHead = list[cur].nextInd;
        list[cur].nextInd = -2;
        list[cur].placeNum = -1;
        list[cur].rowNum = -1;
    }
    ticketLength--;
    ConsoleCleaner();
    cout << "Ticket with " << ind << " number was deleted!";
    printf("\n----------------------------------------------------------------------------------\n");
    return;
}

void RemoveElement(Order *list, int ind) //For orders
{
    int cur = orderHead;
    int prev = orderHead;
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
        orderHead = list[cur].nextInd;
        list[cur].nextInd = -2;
        list[cur].placeNum = -1;
        list[cur].rowNum = -1;
        list[cur].secondName = "";
    }
    orderLength--;
    ConsoleCleaner();
    cout << "Order with " << ind << " number was deleted!";
    printf("\n----------------------------------------------------------------------------------\n");
    return;
}

void Edit(Ticket *list, Order *orderList, int ind)
{
    int cur = ticketHead;
    int tempRow, tempPlace;
    string tempSecondName = "";
    cout << "Enter row number: ";
    tempRow = NumGetter();
    cout << "Enter place number: ";
    tempPlace = NumGetter();
    if (tempRow >= 1 && tempRow <= maxRow && tempPlace >= 1 && tempPlace <= maxPlace)
    {
        if (AviabilityChecker(list, orderList, tempRow, tempPlace))
        {
            if (ind != 1)
            {
                for (int i = 1; i < ind; i++)
                {
                    cur = list[cur].nextInd;
                }
                list[cur].placeNum = tempPlace;
                list[cur].rowNum = tempRow;
            }
            if (ind == 1)
            {
                list[cur].placeNum = tempPlace;
                list[cur].rowNum = tempRow;
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

void Edit(Order *orderList, Ticket *list, int ind)
{
    int cur = orderHead;
    int tempRow, tempPlace;
    string tempSecondName = "";
    cout << "Enter row number: ";
    tempRow = NumGetter();
    cout << "Enter place number: ";
    tempPlace = NumGetter();
    cout << "Enter second name: ";
    cin >> tempSecondName;
    if (tempRow >= 1 && tempRow <= maxRow && tempPlace >= 1 && tempPlace <= maxPlace)
    {
        if (AviabilityChecker(list, orderList, tempRow, tempPlace))
        {
            if (ind != 1)
            {
                for (int i = 1; i < ind; i++)
                {
                    cur = orderList[cur].nextInd;
                }
                orderList[cur].placeNum = tempPlace;
                orderList[cur].rowNum = tempRow;
                orderList[cur].secondName = tempSecondName;
            }
            if (ind == 1)
            {
                orderList[cur].placeNum = tempPlace;
                orderList[cur].rowNum = tempRow;
                orderList[cur].secondName = tempSecondName;
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

void Search(Ticket *list, Order *orderList, int rowNum, int placeNum)
{
    bool checker = false;
    if (ticketHead != -1)
    {
        int ind = ticketHead;
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
            cout << "Purchace was found!\n";
            cout << "Order: " << i;
            cout << "\nRow: " << list[ind].rowNum;
            cout << "\nPlace: " << list[ind].placeNum;
            cout << "\nNext element ind: " << list[ind].nextInd;
            printf("\n----------------------------------------------------------------------------------\n");
            return;
        }
        if (!checker)
        {
            ConsoleCleaner();
            cout << "Such a purchace wasn't found!";
            printf("\n----------------------------------------------------------------------------------\n");
        }
    }

    bool orderChecker = false;
    if (orderHead != -1)
    {
        int ind = orderHead;
        int i = 1;
        while (true)
        {
            if (orderList[ind].rowNum == rowNum && orderList[ind].placeNum == placeNum)
            {
                orderChecker = true;
                break;
            }
            if (orderList[ind].nextInd == -1)
            {
                break;
            }
            else
            {
                ind = orderList[ind].nextInd;
                i++;
            }
        }
        if (orderChecker)
        {
            ConsoleCleaner();
            cout << "Order was found!\n";
            cout << "Order: " << i;
            cout << "\nRow: " << orderList[ind].rowNum;
            cout << "\nPlace: " << orderList[ind].placeNum;
            cout << "\nSecond name: " << orderList[ind].secondName;
            cout << "\nNext element ind: " << orderList[ind].nextInd;
            printf("\n----------------------------------------------------------------------------------\n");
            return;
        }
        if (!orderChecker)
        {
            ConsoleCleaner();
            cout << "Such an order wasn't found!";
            printf("\n----------------------------------------------------------------------------------\n");
        }
    }
}

void Search(Order *list, string secondName)
{
    ConsoleCleaner();
    bool checker = false;
    if (orderHead != -1)
    {
        int ind = orderHead;
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
            cout << "Such an order wasn't found!";
            printf("\n----------------------------------------------------------------------------------\n");
        }
    }
}

void PlacesInARow(Ticket *list, Order *orderList, int rowNum)
{
    int remainingSeats = maxPlace;
    if (ticketHead != -1)
    {
        int ind = ticketHead;
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
    if (orderHead != -1)
    {
        int ind = orderHead;
        while (true)
        {
            if (orderList[ind].rowNum == rowNum)
            {
                remainingSeats--;
            }
            if (orderList[ind].nextInd == -1)
            {
                break;
            }
            else
            {
                ind = orderList[ind].nextInd;
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

int EmptySpaceFinder(Order *list)
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

bool AviabilityChecker(Ticket *list, Order *orderList, int rowNum, int placeNum)
{
    if (ticketHead != -1)
    {
        int ind = ticketHead;
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
    if (orderHead != -1)
    {
        int ind = orderHead;
        while (true)
        {
            if (orderList[ind].rowNum == rowNum && orderList[ind].placeNum == placeNum)
                return false;
            if (orderList[ind].nextInd == -1)
                break;
            else
                ind = orderList[ind].nextInd;
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

void List(Ticket *list, Order *orderList)
{
    if (ticketHead != -1)
    {
        int ind = ticketHead;
        int i = 1;
        while (true)
        {
            cout << "Order: " << i;
            cout << "\nRow: " << list[ind].rowNum;
            cout << "\nPlace: " << list[ind].placeNum;
            cout << "\nNext element ind: " << list[ind].nextInd;
            printf("\n----------------------------------------------------------------------------------\n");
            ind = list[ind].nextInd;
            i++;
            if (ind == -1)
            {
                break;
            }
        }
        cout << "Purchaces amount: " << ticketLength;
        printf("\n----------------------------------------------------------------------------------\n");
    }

    if (orderHead != -1)
    {
        int ind = orderHead;
        int i = 1;
        while (true)
        {
            cout << "Order: " << i;
            cout << "\nRow: " << orderList[ind].rowNum;
            cout << "\nPlace: " << orderList[ind].placeNum;
            cout << "\nOwner: " << orderList[ind].secondName;
            cout << "\nNext element ind: " << orderList[ind].nextInd;
            printf("\n----------------------------------------------------------------------------------\n");
            ind = orderList[ind].nextInd;
            i++;
            if (ind == -1)
            {
                break;
            }
        }
        cout << "Orders amount: " << orderLength;
        printf("\n----------------------------------------------------------------------------------\n");
    }
}

void ConsoleCleaner()
{
    printf("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
}