using System;
using System.Collections.Generic;

internal class Solution
{
    private const string YES = "YES";
    private const string NO = "NO";
    private static readonly Dictionary<int , bool> dict = new Dictionary<int , bool>();

    // Complete the abbreviation function below.
    private static string abbreviation(string a , string b)
    {
        //Debugger.Launch();
        dict.Clear();
        return abbreviation(a , 0 , b , 0) ? YES : NO;
    }

    private static bool abbreviation(string a , int ia , string b , int ib)
    {
        var key = ia * 10000 + ib;
        if (dict.ContainsKey(key))
            return dict[key];
        if (ia == a.Length)
            return dict[key] = false;
        if (ib == b.Length)
            return dict[key] = true;
        if (a[ia] == b[ib])
            return dict[key] = abbreviation(a , ia + 1 , b , ib + 1);
        if (char.ToUpper(a[ia]) == b[ib])
        {
            if (!(dict[key] = abbreviation(a , ia + 1 , b , ib + 1)))
                dict[key] = abbreviation(a , ia + 1 , b , ib);
            return dict[key];
        }
        if (char.IsUpper(a[ia]))
            return dict[key] = false;
        return dict[key] = abbreviation(a , ia + 1 , b , ib);
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
