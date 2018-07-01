using System;

class Solution
{

    // Complete the arrayManipulation function below.
    static long arrayManipulation(long n, long[][] queries)
    {
        var arr = new long[n];
        foreach (long[] q in queries)
        {
            arr[q[0] - 1] += q[2];
            if (q[1] < n)
                arr[q[1]] -= q[2];
        }

        long max = long.MinValue, currentValue = 0;
        for (long i = 0; i < n; i++)
        {
            currentValue = currentValue + arr[i];
            max = Math.Max(max, currentValue);
        }

        return max;
    }

    static void Main(string[] args)
    {
        string[] nm = Console.ReadLine().Split(' ');

        long n = Convert.ToInt64(nm[0]);

        int m = Convert.ToInt32(nm[1]);

        var queries = new long[m][];

        for (int i = 0; i < m; i++)
        {
            queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt64(queriesTemp));
        }

        long result = arrayManipulation(n, queries);

        Console.WriteLine(result);
    }
}