using System;
using System.Linq;
class Solution
{
    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] tokens = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(tokens, Int32.Parse);

        int neg = arr.Count(k => k < 0);
        int pos = arr.Count(k => k > 0);
        int zero = arr.Count(k => k == 0);

        Console.WriteLine(GetAnswer(pos, arr.Length));
        Console.WriteLine(GetAnswer(neg, arr.Length));
        Console.WriteLine(GetAnswer(zero, arr.Length));
    }

    private static string GetAnswer(int a, int b)
    {
        return Math.Round(a / (b * 1d), 6).ToString("F6");
    }
}