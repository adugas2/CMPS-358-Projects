// Austin Dugas
// C00231110
// CMPS 358
// Assignment: a2b_3

// Sample 1: Show default constructor works
Dirt dirt1 = new Dirt();
Console.WriteLine($"There are {dirt1.GetSandAmount()} grams of sand and {dirt1.GetClayAmount()} grams of clay in sample 1");

// Sample 2: Show parameterized constructor works
Dirt dirt2 = new Dirt(3, 5);
Console.WriteLine($"There are {dirt2.GetSandAmount()} grams of sand and {dirt2.GetClayAmount()} grams of clay in sample 2");

// Sample 3: Show the increase/decrease functionality
Dirt dirt3 = new Dirt(0, 0);
Console.WriteLine($"There are {dirt3.GetSandAmount()} grams of sand and {dirt3.GetClayAmount()} grams of clay in sample 3");
// Increase each soil type amount
dirt3.IncreaseSandAmount();
dirt3.IncreaseClayAmount();
// Display results
Console.WriteLine($"After incrementing each soil type, there are now {dirt3.GetSandAmount()} grams of sand and " +
                  $"{dirt3.GetClayAmount()} grams of clay in sample 3");
// Decrease each soil type amount
dirt3.DecreaseSandAmount();
dirt3.DecreaseClayAmount();
// Display results
Console.WriteLine($"After reducing each soil type, there are now {dirt3.GetSandAmount()} grams of sand and " +
                  $"{dirt3.GetClayAmount()} grams of clay in sample 3");
// Show that soil values cannot go below zero
dirt3.DecreaseSandAmount();
dirt3.DecreaseClayAmount();
Console.WriteLine($"After reducing each soil type again, there are now {dirt3.GetSandAmount()} grams of sand and " +
                  $"{dirt3.GetClayAmount()} grams of clay in sample 3");

// Sample 4: Show the parameterized constructor will not allow values below zero
Dirt dirt4 = new Dirt(9, -9);
Console.WriteLine($"There are {dirt4.GetSandAmount()} grams of sand and {dirt4.GetClayAmount()} grams of clay in sample 4");
dirt4 = new Dirt(-9, 9);
Console.WriteLine($"There are {dirt4.GetSandAmount()} grams of sand and {dirt4.GetClayAmount()} grams of clay in sample 4");

public class Dirt
{
    // Initialize the variables
    private double sandAmt;
    private double clayAmt;
    
    // Default Constructor
    public Dirt()
    {
    }

    // Parameterized Constructor
    public Dirt(double x, double y)
    {
        if (x >= 0)
        {
            sandAmt = x;
        }

        if (y >= 0)
        {
            clayAmt = y;
        }
    }

    // Get Sand function
    public double GetSandAmount()
    {
        return sandAmt;
    }

    // Increment Sand function
    public void IncreaseSandAmount()
    {
        sandAmt++;
    }
    
    // Decrement Sand function
    public void DecreaseSandAmount()
    {
        if (sandAmt > 0)
        {
            sandAmt--;
        }
    }
    
    // Get Clay function
    public double GetClayAmount()
    {
        return clayAmt;
    }
    
    // Increment Clay function
    public void IncreaseClayAmount()
    {
        clayAmt++;
    }
    
    // Decrement Clay function
    public void DecreaseClayAmount()
    {
        if (clayAmt > 0)
        {
            clayAmt--;
        }
    }
}