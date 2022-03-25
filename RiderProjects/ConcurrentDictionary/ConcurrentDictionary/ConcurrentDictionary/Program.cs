using System.Collections.Concurrent;
using System.Diagnostics;

internal class Program
{
    private const string Item = "Dictionary Item";
    private const int Iterations = 10000000;
    public static string CurrentItem;

    public static void Main(string[] args)
    {
        var concurrentDictionary = new ConcurrentDictionary<int, string>();
        var dictionary = new Dictionary<int, string>();
        var sw = new Stopwatch();

        // course grain locking
        sw.Restart();
        for (var i = 0; i < Iterations; i++)
            lock (dictionary)
            {
                dictionary[i] = Item;
            }

        Console.WriteLine($"Writing to dictionary with a lock: {sw.Elapsed}");

        Console.WriteLine();

        // fine grain locking
        sw.Restart();
        for (var i = 0; i < Iterations; i++) concurrentDictionary[i] = Item;
        sw.Stop();
        Console.WriteLine($"Writing to concurrent dictionary:  {sw.Elapsed}");

        Console.WriteLine();

        // course grain locking
        sw.Restart();
        for (var i = 0; i < Iterations; i++)
            lock (dictionary)
            {
                CurrentItem = dictionary[i];
            }

        Console.WriteLine($"Reading from dictionary with a lock: {sw.Elapsed}");

        Console.WriteLine();

        // fine grain locking
        sw.Restart();
        for (var i = 0; i < Iterations; i++) CurrentItem = concurrentDictionary[i];
        sw.Stop();
        Console.WriteLine($"Reading from concurrent dictionary:  {sw.Elapsed}");
    }
}