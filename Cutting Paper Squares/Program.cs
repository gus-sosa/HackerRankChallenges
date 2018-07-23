using System;
class Solution
{

    static ulong solve(ulong n, ulong m)
    {
        return n * m - 1;
    }

    static void Main(String[] args)
    {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int m = Convert.ToInt32(tokens_n[1]);
        ulong result = solve(Convert.ToUInt64(n), Convert.ToUInt64(m));
        Console.WriteLine(result);
    }
}