using System;
using System.Collections.Generic;
class Solution
{
    static Dictionary<int, int> CyclesHeight = new Dictionary<int, int>() { [0] = 1 };
    static void Main(String[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(GetHeight(n));
        }
    }

    private static int GetHeight(int n)
    {
        return CyclesHeight.ContainsKey(n) ? CyclesHeight[n] :
                (CyclesHeight[n] = n % 2 != 0 ? 2 * GetHeight(n - 1) : 1 + GetHeight(n - 1));
    }
}