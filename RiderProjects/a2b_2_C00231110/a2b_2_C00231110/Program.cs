// Austin Dugas
// C00231110
// CMPS 358
// Assignment: a2b_2

// Function that converts the user's input of a measurement value in feet
// to meters
static double FeetToMeters(double feet)
{
    return feet * 0.3048;
}

// Ask the user for input
Console.Write("Enter the measurement in feet: ");
var measurement = Double.Parse(Console.ReadLine());

// Check for bad input
if (measurement < 0)
{
    measurement *= -1;
}

// Display the output
double conversion = FeetToMeters(measurement);
Console.WriteLine($"{measurement} feet is equivalent to {conversion} meters");


