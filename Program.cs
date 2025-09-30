using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

class TextStatistics
{
    public string ShortestWord;
    public string LongestWord;
    public int WordCount;
    public int SentenceCount;
    public int VowelCount;
    public int ConsonantCount;
    public Dictionary<char, int> LetterFrequency = new Dictionary<char, int>();

    public void Print()
    {
        Console.WriteLine("STatistika teksta");
        Console.WriteLine($"Words: {WordCount}");
        Console.WriteLine($"Sentences: {SentenceCount}");
        Console.WriteLine($"Thhe most korotkoe word: {ShortestWord}");
        Console.WriteLine($"The most dlinnoe word: {LongestWord}");
        Console.WriteLine($"Glasnih: {VowelCount}");
        Console.WriteLine($"Soglasnih: {ConsonantCount}");
        Console.WriteLine("Frequency bukw:");
        foreach (var pair in LetterFrequency)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }
}

class Program
{
    // if glasnyaya
    static bool IsVowel(char c)
    {
        char lower = Char.ToLower(c);
        return "аеёиоуыэюя".IndexOf(lower) >= 0;
    }

    static TextStatistics AnalyzeText(string text)
    {
        TextStatistics stats = new TextStatistics();

        string[] words = text.Split(new char[] { ' ', ',', '.', '!', '?', ';', ':', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        stats.WordCount = words.Length;

        // the most korotkoe and dlinnoe
        stats.ShortestWord = words[0];
        stats.LongestWord = words[0];

        for (int i = 0; i < words.Length; i++)
        {
            string w = words[i];
            if (w.Length < stats.ShortestWord.Length) stats.ShortestWord = w;
            if (w.Length > stats.LongestWord.Length) stats.LongestWord = w;
        }

        // Sentences
        string[] sentences = text.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        stats.SentenceCount = sentences.Length;

        // Bukws count and stats
        foreach (char c in text)
        {
            if (Char.IsLetter(c))
            {
                char lower = Char.ToLower(c);

                if (IsVowel(lower)) stats.VowelCount++;
                else stats.ConsonantCount++;

                if (!stats.LetterFrequency.ContainsKey(lower))
                    stats.LetterFrequency[lower] = 0;
                stats.LetterFrequency[lower]++;
            }
        }

        return stats;
    }

    static void Main()
    {
        PublicKey static void
        List<TextStatistics> history = new List<TextStatistics>();
        Console.WriteLine("if u want to do that shit print 1, if u want to see history print 2, either print 0");
        string i = Console.ReadLine();
        switch (i)
        {
            case "1":
                Console.WriteLine("Input text (at least100 simvolow:");
                string input = Console.ReadLine();

                if (input.Length < 100)
                    {
                        Console.WriteLine("Dlinnee nado");
                }

                TextStatistics result = AnalyzeText(input);
                history.Add(result);

                result.Print();
                break;
            case "2":
                foreach(TextStatistics g in  history)
                {
                    Console.WriteLine(g);
                }
                break;
            case "0":
                break;
        }
        Main();
       
    }
}