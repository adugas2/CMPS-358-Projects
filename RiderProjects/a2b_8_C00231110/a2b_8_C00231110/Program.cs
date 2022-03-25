// Austin Dugas
// C00231110
// CMPS 358
// Assignment: a2b_8

// Method that randomly assigns values to a list including null values
static int?[] WorstPopulate()
{
    Random random = new Random();
    int?[] a = new int?[random.Next(10) + 10];
    for(int i = 0; i < a.Length; i++)
        if (random.Next(2) == 1)
            a[i] = random.Next(10) + 1;
    return a;
}

// Call WorstPopulate to create a list
int?[] list = WorstPopulate();

// Sum all elements that are not null
Console.WriteLine("The elements of the list:");
int sum = 0;
for (int i = 0; i < list.Length; i++)
{
    if (list[i] == null) Console.Write("null ");
    else Console.Write($"{list[i]} ");
    sum = list[i] + sum ?? 0 + sum;
}

// Display the sum
Console.WriteLine();
Console.WriteLine();
Console.WriteLine($"The sum of the list of integers is {sum}");