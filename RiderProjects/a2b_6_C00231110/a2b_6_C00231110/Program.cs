// Austin Dugas
// C00231110
// CMPS 358
// Assignment: a2b_6

// Base sample used to compare to other samples
Dirt sample1 = new Dirt();
sample1.SandAmt = 1;
sample1.ClayAmt = 1;
Console.WriteLine($"The amount of sand in sample 1 is {sample1.SandAmt} and the amount of clay is {sample1.ClayAmt}");
Console.WriteLine();

// Compare sample 1 and sample 2 to show they have equal sand amounts using CompareTo
Dirt sample2 = new Dirt();
sample2.SandAmt = 1.1;
sample2.ClayAmt = 5;
Console.WriteLine($"The amount of sand in sample 1 is {sample2.SandAmt} and the amount of clay is {sample2.ClayAmt}");
Console.WriteLine($"Comparing sample 1 and 2's sand amounts results in a {sample1.CompareTo(sample2)}");
Console.WriteLine("This means that sample 1 and 2 have an equal amount of sand in each sample");
Console.WriteLine();

// Compare sample 1 and sample 3 to show sample 1 has a greater sand amount using CompareTo
Dirt sample3 = new Dirt();
sample3.SandAmt = .5;
sample2.ClayAmt = 5;
Console.WriteLine($"The amount of sand in sample 3 is {sample3.SandAmt} and the amount of clay is {sample3.ClayAmt}");
Console.WriteLine($"Comparing sample 1 and 3's sand amounts results in a {sample1.CompareTo(sample3)}");
Console.WriteLine("This means that sample 1 has a greater amount of sand than sample 3");
Console.WriteLine();

// Compare sample 1 and sample 4 to show sample 1 has a lesser sand amount using CompareTo
Dirt sample4 = new Dirt();
sample4.SandAmt = 1.3;
sample4.ClayAmt = 5;
Console.WriteLine($"The amount of sand in sample 4 is {sample4.SandAmt} and the amount of clay is {sample4.ClayAmt}");
Console.WriteLine($"Comparing sample 1 and 4's sand amounts results in a {sample1.CompareTo(sample4)}");
Console.WriteLine("This means that sample 1 has a lesser amount of sand than sample 4");
Console.WriteLine();

public class DirtExtension
{
    public static void DisplayTotal(Dirt sample)
    {
        Console.WriteLine($"Total grams of sand and clay in the sample: {sample.SandAmt + sample.ClayAmt} grams");
    }
}

public class Dirt : IComparable<Dirt>
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

    public int CompareTo(Dirt sample)
    {
        if (this.Equals(sample)) return 0;
        else if (sandAmt > sample.sandAmt * 1.1) return 1;
        else return -1;
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