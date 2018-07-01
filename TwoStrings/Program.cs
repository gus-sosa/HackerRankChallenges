using System.Collections.Generic;
using System.Linq;
using System;

class Solution
{
    private static readonly char[] alphabetArray = "abcdefghijklmnopqrstuvwxyz".ToArray();
    const string YES = "YES";
    const string NO = "NO";
    // Complete the twoStrings function below.
    static string twoStrings(string s1, string s2)
    {
        var hash1 = new HashSet<char>();
        var hash2 = new HashSet<char>();
        AddToHash(s1, hash1);
        AddToHash(s2, hash2);
        foreach (char c in alphabetArray)
            if (hash1.Contains(c) && hash2.Contains(c))
                return YES;
        return NO;
    }

    private static void AddToHash(string cad, HashSet<char> hash)
    {
        foreach (var item in cad)
            hash.Add(item);
    }

    static void Main(string[] args)
    {
        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s1 = Console.ReadLine();

            string s2 = Console.ReadLine();

            string result = twoStrings(s1, s2);

            Console.WriteLine(result);
        }
    }
}