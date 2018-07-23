using System;
class Solution
{
    static void Main(String[] args)
    {
        int N = Convert.ToInt32(Console.ReadLine());
        string[] B_temp = Console.ReadLine().Split(' ');
        int[] B = Array.ConvertAll(B_temp, Int32.Parse);


        int countLoavesDistribution = 0;
        for (int i = 0; i < N - 1; i++)
        {
            int current = B[i];
            if (current % 2 == 1)//odd
            {
                countLoavesDistribution += 2;
                B[i]++;
                B[i + 1]++;
            }
        }

        Console.WriteLine(B[N - 1] % 2 == 0 ? countLoavesDistribution.ToString() : "NO");
    }
}