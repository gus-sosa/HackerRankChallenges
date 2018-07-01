using System.IO;
using System.Linq;
using System;

class Solution
{

    // Complete the arrayManipulation function below.
    static long arrayManipulation(int n, int[][] queries)
    {
        long[] arr = new long[n];
        foreach (int[] q in queries)
        {
            int a = q[0] - 1, b = q[1] - 1, k = q[2];
            for (int i = a; i <= b; i++)
                arr[i] += k;
        }
        return arr.Max();
    }

    static void Main(string[] args)
    {
        string[] nm = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nm[0]);

        int m = Convert.ToInt32(nm[1]);

        int[][] queries = new int[m][];

        for (int i = 0; i < m; i++)
        {
            queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
        }

        long result = arrayManipulation(n, queries);

        Console.WriteLine(result);
    }
}