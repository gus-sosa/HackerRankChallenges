using System;

class Solution
{

    // Complete the arrayManipulation function below.
    static ulong arrayManipulation(ulong n, ulong[][] queries)
    {
        var arr = new ulong[n];
        foreach (ulong[] q in queries)
        {
            arr[q[0]] += q[2];
            if (q[1] < n)
                arr[q[1]] -= q[2];
        }

        ulong max = ulong.MinValue, currentValue = 0;
        for (ulong i = 0; i < n; i++)
        {
            currentValue = currentValue + arr[i];
            max = Math.Max(max, currentValue);
        }

        return max;
    }

    static void Main(string[] args)
    {
        string[] nm = Console.ReadLine().Split(' ');

        ulong n = Convert.ToUInt64(nm[0]);

        int m = Convert.ToInt32(nm[1]);

        var queries = new ulong[m][];

        for (int i = 0; i < m; i++)
        {
            queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToUInt64(queriesTemp));
        }

        ulong result = arrayManipulation(n, queries);

        Console.WriteLine(result);
    }
}