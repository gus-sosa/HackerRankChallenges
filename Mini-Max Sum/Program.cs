using System;
class Solution
{
    static void Main(String[] args)
    {
        string[] tokens = Console.ReadLine().Split(' ');
        int[] nums = Array.ConvertAll(tokens, Convert.ToInt32);
        long sum = 0, minSum = long.MaxValue, maxSum = -1;
        for (int i = 0; i < nums.Length; i++)
            sum += nums[i];

        for (int i = 0; i < nums.Length; i++)
        {
            long tmpSum = sum - nums[i];
            minSum = Math.Min(minSum, tmpSum);
            maxSum = Math.Max(maxSum, tmpSum);
        }

        Console.WriteLine($"{minSum} {maxSum}");
    }
}