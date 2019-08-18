using System;
using System.Collections.Generic;
using System.Linq;

internal class Solution
{
    // Complete the sockMerchant function below.
    private static int sockMerchant(int n, int[] ar)
    {
        Dictionary<int, int> dict = GetNumSockPerColor(ar);
        return GetSumOfPais(dict);
    }

    private static int GetSumOfPais(Dictionary<int, int> dict)
    {
        var sum = 0;
        foreach (var numSocks in dict.Values)
            sum += numSocks / 2;
        return sum;
    }

    private static Dictionary<int, int> GetNumSockPerColor(int[] ar)
    {
        var dict = new Dictionary<int, int>();
        foreach (var num in ar)
        {
            if (!dict.ContainsKey(num))
                dict[num] = 0;
            dict[num] = dict[num] + 1;
        }
        return dict;
    }

    private static void Main(string[] args)
    {
        var n = Convert.ToInt32(Console.ReadLine());
        var arr = Array.ConvertAll(Console.ReadLine().Split(' ').Where(v => !string.IsNullOrEmpty(v)).ToArray(), arTemp => Convert.ToInt32(arTemp));
        var result = sockMerchant(n, arr);
        Console.WriteLine(result);
    }
}