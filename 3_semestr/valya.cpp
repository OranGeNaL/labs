class SomeClass
{
    int x;
    double y;

    SomeClass()
    {

    }
    SomeClass(int _x, double _y)
    {
        x = _x;
        y = _y;
    }
    SomeClass(int _x, double _y):x(_x), y(_y)
    {
        
    }

};