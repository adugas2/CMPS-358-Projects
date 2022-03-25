using System.Collections.Concurrent;
using System.Diagnostics;

internal class Program
{
    private const string Item = "Dictionary Item";
    private const int Iterations = 10000000;
    private const int NumThreads = 10;
    public static string CurrentItem;

    static ConcurrentDictionary<int, string> concurrentDictionary = new ConcurrentDictionary<int, string>();
    static Dictionary<int, string> dictionary = new Dictionary<int, string>();
    static Stopwatch sw = new Stopwatch();

    public static void Main(String[] args)
    {
        for (int i = 0; i < NumThreads / 2; i++)
        {
             new Thread(WriteToDictionary).Start();
             new Thread(WriteToConcurrentDictionary).Start();
             new Thread(ReadToDictionary).Start();
             //new Thread(ReadToConcurrentDictionary).Start();
        }
        
        for (int i = 0; i < NumThreads / 2; i++)
        {
            new Thread(WriteToDictionary).Start();
            new Thread(WriteToConcurrentDictionary).Start();
            new Thread(ReadToDictionary).Start();
            //new Thread(ReadToConcurrentDictionary).Start();
        }
    }

    static void WriteToDictionary()
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

    static void WriteToConcurrentDictionary()
    {
        // fine grain locking
        sw.Restart();
        for (var i = 0; i < Iterations; i++)
        {
            concurrentDictionary[i] = Item;
        }
        sw.Stop();
        Console.WriteLine($"Writing to concurrent dictionary: {sw.Elapsed}");
    }

    static void ReadToDictionary()
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

    static void ReadToConcurrentDictionary()
    {
        // fine grain locking
        sw.Restart();
        for (var i = 0; i < Iterations; i++)
        {
            CurrentItem = concurrentDictionary[i];
        }
        sw.Stop();
        Console.WriteLine($"Reading from concurrent dictionary:  {sw.Elapsed}");
    }
}