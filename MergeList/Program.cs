using System;

class Solution
{
    private static int[,] map;
    static void Main(String[] args)
    {
        PreComputeCombinations();

        int t = int.Parse(Console.ReadLine());
        while (t-- > 0)
        {
            string[] tokens = Console.ReadLine().Split();
            int n = int.Parse(tokens[0]), m = int.Parse(tokens[1]);
            Console.WriteLine(map[n + m, m]);
        }
    }

    private static void PreComputeCombinations()
    {
        int maxLength = 201;
        int module = (int)Math.Pow(10, 9) + 7;
        map = new int[maxLength, maxLength];
        for (int i = 0; i < maxLength; i++)
            map[i, 0] = map[i, i] = 1;

        for (int i = 2; i < maxLength; i++)
            for (int j = 1; j < i; j++)
                map[i, j] = (map[i - 1, j] + map[i - 1, j - 1]) % module;
    }
}