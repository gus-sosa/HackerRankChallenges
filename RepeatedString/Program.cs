using System;
using System.Linq;

internal class Solution
{

    // Complete the repeatedString function below.
    private static long repeatedString(string s, long n)
    {
        long length = s.Length, numAinS = GetNumA(s), timesSinN = n / length, numAinFirstChars = GetNumA(s, (int)(n % length));
        return numAinS * timesSinN + numAinFirstChars;
    }

    private static long GetNumA(string s, int numFirstChars)
    {
        long sum = 0;
        foreach (var c in s.Take(numFirstChars))
            if (c == 'a')
                ++sum;
        return sum;
    }

    private static long GetNumA(string s) => GetNumA(s, s.Length);

    private static void Main(string[] args)
    {
        var s = Console.ReadLine();
        var n = Convert.ToInt64(Console.ReadLine());
        var result = repeatedString(s, n);
        Console.WriteLine(result);
    }
}