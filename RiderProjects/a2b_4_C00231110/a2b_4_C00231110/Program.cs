// Austin Dugas
// C00231110
// CMPS 358
// Assignment: a2b_4

// Show the get and set work for good input
Dirt sample1 = new Dirt();
sample1.SandAmt = 8;
sample1.ClayAmt = 5;
Console.WriteLine($"The amount of sand in the first dirt sample is {sample1.SandAmt} grams and the amount of " +
                  $"clay in the first dirt sample is {sample1.ClayAmt} grams");
// Also show the set increasing/decreasing the amount of a particular soil type
sample1.SandAmt = 2;
sample1.ClayAmt = 4;
Console.WriteLine($"After increasing the soil types, the amount of sand in the first dirt sample is {sample1.SandAmt} " +
                  $"grams and the amount of clay in the first dirt sample is {sample1.ClayAmt} grams");
sample1.SandAmt = -2;
sample1.ClayAmt = -10;
Console.WriteLine($"After decreasing the soil types, the amount of sand in the first dirt sample is {sample1.SandAmt} " +
                  $"grams and the amount of clay in the first dirt sample is {sample1.ClayAmt} grams");

// Show the set doesn't accept values lower than 0
Dirt sample2 = new Dirt();
sample2.SandAmt = -9;
sample2.ClayAmt = -77;
Console.WriteLine($"The amount of sand in the second dirt sample is {sample2.SandAmt} grams and the amount of " +
                 $"clay in the second dirt sample is {sample2.ClayAmt} grams");

// Show the functionality of the expression bodied method
Dirt sample3 = new Dirt();
sample3.ClayAmt = 6;
sample3.SandAmt = 9;
Console.WriteLine($"The amount of sand in the third dirt sample is {sample3.SandAmt} grams and the amount of " +
                  $"clay in the third dirt sample is {sample3.ClayAmt} grams");
Console.WriteLine($"The total amount of sand and clay in the third sample is {sample3.Total()} grams");

public class Dirt
{
    // Initialize the variables
    private double sandAmt;
    private double clayAmt;

    public double SandAmt
    {
        get => sandAmt;
        set
        {
            if (sandAmt + value >= 0)
            {
                sandAmt += value;
            }
            else
            {
                sandAmt = 0;
            }
        }
    }
    
    public double ClayAmt
    {
        get => clayAmt;
        set
        {
            if (clayAmt + value >= 0)
            {
                clayAmt += value;
            }
            else
            {
                clayAmt = 0;
            }
        }
    }

    public double Total() => sandAmt + clayAmt;
}