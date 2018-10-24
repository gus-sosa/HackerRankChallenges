using System;

internal class Solution
{

    // Complete the maxSubsetSum function below.
    private static int maxSubsetSum(int[] arr)
    {
        return 0;
    }

    private static void Main(string[] args)
    {
        var n = Convert.ToInt32(Console.ReadLine());
        var arr = Array.ConvertAll(Console.ReadLine().Split(' ') , arrTemp => Convert.ToInt32(arrTemp));
        var res = maxSubsetSum(arr);
        Console.WriteLine(res);
    }
}
