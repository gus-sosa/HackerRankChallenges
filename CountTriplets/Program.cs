using System;
using System.Diagnostics;
using System.Linq;

class Solution
{
    const long NO_VALUE = -1;
    // Complete the countTriplets function below.
    static long countTriplets(long[] arr, long r)
    {
        if (r == 1)
            return countTripletsOfOnes(arr.Count());
        ConvertArrToRPower(arr, r);

        int num = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                for (int k = 0; k < arr.Length; k++)
                {
                    long a = arr[i], b = arr[j], c = arr[k];
                    if (b - a == 1 && c - b == 1)
                        num++;
                }
            }
        }
        return num;
    }

    private static long countTripletsOfOnes(long n) => n * (n - 1) * (n - 2) / 6;

    private static void ConvertArrToRPower(long[] arr, long r)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            double tmp = Math.Log(arr[i], r);
            long newValue = Convert.ToInt64(tmp);
            arr[i] = tmp == newValue ? newValue : NO_VALUE;
        }
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
