using System;
using System.Collections.Generic;
class Solution
{
    static IDictionary<string, int> mem = new Dictionary<string, int>();

    private static int minSteps(int pos, string b)
    {
        if (b.Length - pos < 3)
            return b.Contains("010") ? int.MaxValue : 0;

        if (mem.ContainsKey(b))
            return mem[b];

        if (b[pos] == '0')
        {
            int steps = minSteps(pos + 1, $"{b.Remove(pos)}1{b.Substring(pos + 1)}") + 1;
            return mem[b] = Math.Min(steps < 0 ? int.MaxValue : steps, minSteps(pos + 1, b));
        }

        return mem[b] = minSteps(pos + 1, b);
    }

    static void Main(String[] args)
    {
        Console.ReadLine();//skipping n
        string B = Console.ReadLine();
        int result = minSteps(0, B);
        Console.WriteLine(result);
    }
}