using System;
using System.Collections.Generic;
using System.Diagnostics;

internal class Solution
{
    private const string YES = "YES";
    private const string NO = "NO";

    // Complete the abbreviation function below.
    private static string abbreviation(string a , string b)
    {
        Debugger.Launch();

        Dictionary<char , List<int>> map = GetCharMap(a.ToUpper());
        var lastIndex = -1;
        var listIndexes = new List<int>();

        foreach (var c in b)
        {
            if (!map.ContainsKey(c))
                return NO;

            List<int> indexes = map[c];
            lastIndex = GetNextIndex(lastIndex , indexes);
            if (lastIndex == -1)
                return NO;
            listIndexes.Add(lastIndex);
        }

        return YES;
    }

    private static int GetNextIndex(int lastIndex , List<int> indexes)
    {
        var pos = ~indexes.BinarySearch(lastIndex);
        return pos == indexes.Count ? -1 : indexes[pos];
    }

    private static Dictionary<char , List<int>> GetCharMap(string a)
    {
        var map = new Dictionary<char , List<int>>();

        for (var i = 0 ; i < a.Length ; i++)
        {
            var c = a[i];
            if (!map.ContainsKey(c))
                map[c] = new List<int>();
            map[c].Add(i);
        }

        return map;
    }

    private static void Main(string[] args)
    {
        var q = Convert.ToInt32(Console.ReadLine());

        for (var qItr = 0 ; qItr < q ; qItr++)
        {
            var a = Console.ReadLine();

            var b = Console.ReadLine();

            var result = abbreviation(a , b);

            Console.WriteLine(result);
        }
    }
}
