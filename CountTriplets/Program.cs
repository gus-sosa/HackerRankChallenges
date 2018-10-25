using System;
using System.Collections.Generic;
using System.Diagnostics;

class Solution
{
    // Complete the countTriplets function below.
    static long countTriplets(long[] arr, long r) => r == 1 ? countTripletsForRatioEqualOne(arr) : countTripletsForRatioGreaterThanOne(arr, r);

    private static long countTripletsForRatioGreaterThanOne(long[] arr, long r)
    {
        long count = 0;
        var dict = new Dictionary<long, List<int>>();
        for (int i = 0; i < arr.Length; i++)
        {
            long v = arr[i];
            long power;
            if (IsPowerOfR(v, r, out power))
            {
                AddInDict(dict, power, i);
                int numPowerMinusOne = 0, numPowerMinusTwo = 0;
                if (dict.ContainsKey(power - 1))
                    numPowerMinusOne = ~dict[power - 1].BinarySearch(i);
                if (dict.ContainsKey(power - 2))
                    numPowerMinusTwo = ~dict[power - 2].BinarySearch(i);
                count += numPowerMinusOne * numPowerMinusTwo;
            }
        }
        return count;
    }

    private static void AddInDict(Dictionary<long, List<int>> dict, long key, int value)
    {
        if (!dict.ContainsKey(key))
            dict[key] = new List<int>();
        dict[key].Add(value);
    }

    private static bool IsPowerOfR(long value, long r, out long power)
    {
        double tmp = Math.Log(value, r);
        power = Convert.ToInt64(tmp);
        return value == Convert.ToInt64(Math.Pow(r, power));
    }

    private static long countTripletsForRatioEqualOne(long[] arr)
    {
        var dict = new Dictionary<long, long>();
        foreach (long num in arr)
        {
            if (!dict.ContainsKey(num))
                dict[num] = 0;
            dict[num] += 1;
        }
        long count = 0;
        foreach (long value in dict.Values)
            count += value * (value - 1) * (value - 2) / 6;
        return count;
    }

    static void Main(string[] args)
    {
        string[] nr = Console.ReadLine().Split(' ');

        long n = Convert.ToInt64(nr[0]);

        long r = Convert.ToInt64(nr[1]);

        long[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt64(arrTemp))
        ;
        long ans = countTriplets(arr, r);

        Console.WriteLine(ans);
    }
}
