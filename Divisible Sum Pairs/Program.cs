using System;
class Solution
{

    static int divisibleSumPairs(int n, int k, int[] ar)
    {
        int result = 0;
        for (int i = 0; i < n - 1; i++)
        {
            int remainderPiv = ar[i] % k;
            for (int j = i + 1; j < n; j++)
            {
                int currentRemainder = ar[j] % k;
                if ((remainderPiv + currentRemainder) % k == 0)
                    result++;
            }
        }
        return result;
    }

    static void Main(String[] args)
    {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int k = Convert.ToInt32(tokens_n[1]);
        string[] ar_temp = Console.ReadLine().Split(' ');
        int[] ar = Array.ConvertAll(ar_temp, Int32.Parse);
        int result = divisibleSumPairs(n, k, ar);
        Console.WriteLine(result);
    }
}