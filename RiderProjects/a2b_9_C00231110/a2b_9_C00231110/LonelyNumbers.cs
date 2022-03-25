// Namespace of class
namespace Lonely;

// Class that sets entries of type OneLonelyNumber
class OneLonelyNumber
{
    private int a = 0;
    public int A
    {
        get => a;
        set
        {
            if (value > a)
                a = value;
        }
    }
}

// Class that sets entries of type TwoLonelyNumbers that inherits the properties from class OneLonelyNumber
class TwoLonelyNumbers : OneLonelyNumber
{
    private int b = 0;

    public int B
    {
        get => b;
        set
        {
            if (value > b)
                b = value;
        }
    }
}
