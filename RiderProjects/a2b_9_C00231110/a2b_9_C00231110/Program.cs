// Austin Dugas
// C00231110
// CMPS 358
// Assignment: a2b_9

// Namespace of class used in main program
using Lonely;

// Set the array length
var aray = new OneLonelyNumber[10];

// Randomly assign values to array entries. If within a certain threshold, the entry is of type OneLonelyNumber.
// Otherwise it is of type TwoLonelyNumbers
Random random = new Random();
for (int i = 0; i < aray.Length; i++)
{
    if (random.Next(2) >= 1)
    {
        aray[i] = new OneLonelyNumber();
        aray[i].A = random.Next(10);
    }
    else
    {
        var tln = new TwoLonelyNumbers();
        tln.A = random.Next(10);
        tln.B = random.Next(20);
        aray[i] = tln;
    }
}

// Cycles through the array and checks if each entry is of type TwoLonelyNumbers or not and prints the values
// of A and B (B is printed only if the entry is of type TwoLonelyNumbers)
foreach (var c in aray)
{
    if (c is TwoLonelyNumbers x)
    {
        Console.WriteLine($"{x.A} {x.B}");
    }
    else
    {
        Console.WriteLine($"{c.A}");
    }
}