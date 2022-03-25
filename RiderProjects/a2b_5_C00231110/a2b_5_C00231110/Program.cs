// Austin Dugas
// C00231110
// CMPS 358 
// Assignment: a2b_5

// Show the properties work for sample 1
Dirt sample1 = new Dirt();
sample1.SandAmt = 2;
sample1.ClayAmt = 3;
Console.WriteLine($"Sample 1 has {sample1.SandAmt} grams of sand and {sample1.ClayAmt} grams of clay");
// Show the extension that displays the total amount of each soil type in the dirt works
DirtExtension.DisplayTotal(sample1);
Console.WriteLine();

// Use sample 1 and compare it with sample 2 to show they're the same when sample1 > sample2 * .9
Dirt sample2 = new Dirt();
sample2.SandAmt = 1.9;
sample2.ClayAmt = 0;
Console.WriteLine($"Sample 2 has {sample2.SandAmt} grams of sand and {sample2.ClayAmt} grams of clay");
Console.WriteLine($"'Sample 1 has the same amount of sand as Sample 2' is a {sample1.Equals(sample2)} statement");
Console.WriteLine();

// Use sample 1 and compare it with sample 3 to show they're not the same
Dirt sample3 = new Dirt();
sample3.SandAmt = 7;
sample3.ClayAmt = 13;
Console.WriteLine($"Sample 3 has {sample3.SandAmt} grams of sand and {sample3.ClayAmt} grams of clay");
Console.WriteLine($"'Sample 1 has the same amount of sand as Sample 3' is a {sample1.Equals(sample3)} statement");
Console.WriteLine();

// Use sample 1 and compare it with sample 4 to show they're the same when sample1 < sample4 * 1.1
Dirt sample4 = new Dirt();
sample4.SandAmt = 2.1;
sample4.ClayAmt = 1;
Console.WriteLine($"Sample 4 has {sample4.SandAmt} grams of sand and {sample4.ClayAmt} grams of clay");
Console.WriteLine($"'Sample 1 has the same amount of sand as Sample 4' is a {sample1.Equals(sample4)} statement");

public class DirtExtension
{
    public static void DisplayTotal(Dirt sample)
    {
        Console.WriteLine($"Total grams of sand and clay in the sample: {sample.SandAmt + sample.ClayAmt} grams");
    }
}

public class Dirt
{
    // Initialize the variables
    private double sandAmt;
    private double clayAmt;

    public override bool Equals(Object o)
    {
        return sandAmt < ((Dirt) o).sandAmt * 1.1 &&
               sandAmt > ((Dirt) o).sandAmt * .9;
    }

    public static bool operator == (Dirt sample1, Dirt sample2)
    {
        return sample1.Equals(sample2);
    }

    public static bool operator != (Dirt sample1, Dirt sample2)
    {
        return !(sample1.Equals(sample2));
    }

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
}