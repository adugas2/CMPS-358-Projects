using System.Diagnostics;

const int numSensors = 15;
const int numSeconds = 28;

var tokenSource = new CancellationTokenSource();
var token = tokenSource.Token;
var tf = new TaskFactory(token);

for (var i = 0; i < numSensors; i++) // one virtual sensor created per pass
    tf.StartNew(() =>
        new SensorSim(), token);

var particlesDetected = 0;
var swatch = Stopwatch.StartNew();
while (swatch.ElapsedMilliseconds < numSeconds * 1000) // number of milliseconds
{
    Thread.Sleep(10);

    if (SensorSim.totalDetected > 3)
    {
        //Console.Write($"{swatch.ElapsedMilliseconds}ms ");
        particlesDetected++;
    }
}

swatch.Stop();
tokenSource.Cancel();
Console.WriteLine("\nSensors: " + numSensors + ", Seconds: " + swatch.ElapsedMilliseconds + ", Particles detected: " + particlesDetected);

internal class SensorSim
{
    public static int totalDetected;
    private readonly Random random = new();

    public SensorSim()
    {
        SensorSensorium();
    }

    public void SensorSensorium()
    {
        while (true)
        {
            Thread.Sleep(random.Next(100));
            totalDetected++;
            Thread.Sleep(random.Next(10));
            if (totalDetected > -1)
                totalDetected--;
        }
    }
}
