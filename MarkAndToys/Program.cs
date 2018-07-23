using System;

class Solution
{

    static int maximumToys(int[] prices, int k)
    {
        Array.Sort(prices);
        int count = 0, sum = 0;
        while (count < prices.Length && sum + prices[count] <= k)
            sum += prices[count++];
        return count;
    }

    static void Main(String[] args)
    {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int k = Convert.ToInt32(tokens_n[1]);
        string[] prices_temp = Console.ReadLine().Split(' ');
        int[] prices = Array.ConvertAll(prices_temp, Int32.Parse);
        int result = maximumToys(prices, k);
        Console.WriteLine(result);
    }
}