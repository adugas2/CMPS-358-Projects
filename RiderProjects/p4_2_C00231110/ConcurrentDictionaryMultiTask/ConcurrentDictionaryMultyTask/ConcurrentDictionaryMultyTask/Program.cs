// Austin Dugas
// C00231110
// CMPS 358
// Project: p4_2

using System.Collections.Concurrent;
using System.Diagnostics;

internal class Program
{
    private const string Item = "Dictionary Item";
    private const int Iterations = 10000000;
    private const int NumCycles = 10;
    public static string CurrentItem;

    ConcurrentDictionary<int, string> concurrentDictionary = new ConcurrentDictionary<int, string>();
    Dictionary<int, string> dictionary = new Dictionary<int, string>();
    Stopwatch sw = new Stopwatch();
    
    public static void Main(String[] args)
    {
        new Program();
    }

    public Program()
    {
        for (int i = 0; i < NumCycles; i++)
        {
            TasksWriteToDictionary().Wait();
        }
        Console.WriteLine();
        for (int i = 0; i < NumCycles; i++)
        {
            TasksWriteToConcurrentDictionary().Wait();
        }
        Console.WriteLine();
        for (int i = 0; i < NumCycles; i++)
        {
            TasksReadToDictionary().Wait();
        }
        Console.WriteLine();
        for (int i = 0; i < NumCycles; i++)
        {
            TasksReadToConcurrentDictionary().Wait();
        }
    }

    async Task TasksWriteToDictionary()
    {
        // course grain locking
        sw.Restart();
        for (var i = 0; i < Iterations; i++)
            lock (dictionary)
            {
                dictionary[i] = Item;
            }
        Console.WriteLine($"Writing to dictionary with a lock: {sw.Elapsed}");
    }

    async Task TasksWriteToConcurrentDictionary()
    {
        // fine grain locking
        sw.Restart();
        for (var i = 0; i < Iterations; i++)
        {
            concurrentDictionary[i] = Item;
        }
        Console.WriteLine($"Writing to concurrent dictionary: {sw.Elapsed}");
    }

    async Task TasksReadToDictionary()
    {
        // coarse grain locking
        sw.Restart();
        for (var i = 0; i < Iterations; i++)
            lock (dictionary)
            {
                CurrentItem = dictionary[i];
            }
        Console.WriteLine($"Reading from dictionary with a lock: {sw.Elapsed}");
    }

    async Task TasksReadToConcurrentDictionary()
    {
        // fine grain locking
        sw.Restart();
        for (var i = 0; i < Iterations; i++)
        {
            CurrentItem = concurrentDictionary[i];
        }
        Console.WriteLine($"Reading from concurrent dictionary:  {sw.Elapsed}");
    }
}