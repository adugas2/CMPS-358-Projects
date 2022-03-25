// Austin Dugas
// C00231110
// CMPS 358
// Project: p6

using System.Text.RegularExpressions;

void DivvyUpTheWords(List<string> words1, List<string> words2, string path)
{
    Random random = new Random();
   
    var wordFilePath = Path.Combine(Environment.CurrentDirectory, path);
    List<String> allWords = new List<string>(File.ReadAllLines(wordFilePath));

    int n = allWords.Count;
    while (n > 1)
    {
        n--;
        int k = random.Next(n + 1);
        String value = allWords[k];
        allWords[k] = allWords[n];
        allWords[n] = value;
    }

    foreach (var word in allWords)
    {
        var r = random.Next(100);
        if (r < 40) words1.Add(word);
        else if (r > 60) words2.Add(word);
        else
        {
            words1.Add(word);
            words2.Add(word);
        }
    }
}

