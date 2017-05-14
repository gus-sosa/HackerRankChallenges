using System;
class Solution
{

    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] height_temp = Console.ReadLine().Split(' ');
        int[] height = Array.ConvertAll(height_temp, Int32.Parse);
        int maxHeight = height[0];
        int count = 1;
        for (int i = 1; i < n; i++)
            if (maxHeight == height[i])
                count++;
            else
            {
                if (height[i] > maxHeight)
                {
                    maxHeight = height[i];
                    count = 1;
                }
            }

        Console.WriteLine(count);
    }
}
