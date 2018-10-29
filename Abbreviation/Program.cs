using System;
using System.Collections.Generic;
using System.Linq;

internal class Solution
{
    private const string YES = "YES";
    private const string NO = "NO";
    private static readonly Dictionary<int , bool> dict = new Dictionary<int , bool>();
    private static string a;
    private static string b;
    private static readonly char[] capitalLetters = Enumerable.Repeat('A' , 26).Select((c , i) => (char)(c + i)).ToArray();

    // Complete the abbreviation function below.
    private static string abbreviation(string a , string b)
    {
        //Debugger.Launch();
        dict.Clear();
        Solution.a = a;
        Solution.b = b;
        return abbreviation(0 , 0) ? YES : NO;
    }

    private static bool abbreviation(int ia , int ib)
    {
        var key = ia * 10000 + ib;
        if (dict.ContainsKey(key))
            return dict[key];
        if (ia == a.Length)
            return dict[key] = ib == b.Length;
        if (ib == b.Length)
            return dict[key] = a.IndexOfAny(capitalLetters , ia) == -1;//no capital letters found in the rest of "a" string
        if (a[ia] == b[ib])
            return dict[key] = abbreviation(ia + 1 , ib + 1);
        if (char.ToUpper(a[ia]) == b[ib])
        {
            if (!(dict[key] = abbreviation(ia + 1 , ib + 1)))
                dict[key] = abbreviation(ia + 1 , ib);
            return dict[key];
        }
        if (char.IsUpper(a[ia]))
            return dict[key] = false;
        return dict[key] = abbreviation(ia + 1 , ib);
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
