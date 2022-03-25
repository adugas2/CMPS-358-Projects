// Austin Dugas
// C00231110
// CMPS 358
// Assignment: a2b_1

// Function that checks the weight and returns the proper prompt
// that corresponds to the user's input
static string WeightCheck(float weight)
{
    if (weight <= 0)
    {
        return "Data error";
    } 
    else if (weight > 50)
    {
        return "Cannot ship package";
    }
    else
    {
        if (weight > 10)
        {
            return "The cost of shipping your package is $13.50";
        }
        else if (weight > 3)
        {
            return "The cost of shipping your package is $8.50";
        }
        else if (weight > 1)
        {
            return "The cost of shipping your package is $5.50";
        }
        else
        {
            return "The cost of shipping your package is $3.50";
        }
    }
}

// Ask the user for input
Console.Write("Enter the weight for your package: ");
var weight = float.Parse(Console.ReadLine());

// Display the result
string result = WeightCheck(weight);
Console.WriteLine(result);

