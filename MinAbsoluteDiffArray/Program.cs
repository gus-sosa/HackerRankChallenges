using System;

class Solution
{

    // Complete the minimumAbsoluteDifference function below.
    static int minimumAbsoluteDifference(int[] arr)
    {
        Array.Sort(arr);
        int min = int.MaxValue;
        for (int i = 1; i < arr.Length; i++)
            min = Math.Min(min, Math.Abs(arr[i] - arr[i - 1]));
        return min;
    }

    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32)
            ;
        int result = minimumAbsoluteDifference(arr);

        Console.WriteLine(result);
    }
}