using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    static void Main(String[] args)
    {
        int n = int.Parse(Console.ReadLine());

        HashSet<long> fibo = new HashSet<long>();
        fibo.Add(0);
        fibo.Add(1);

        long p1 = 0, p2 = 1;
        while (p2 < 10000000001)
        {
            long p = p1 + p2;
            p1 = p2;
            p2 = p;
            fibo.Add(p);
        }

        for (int i = 0; i < n; i++)
        {
            long t = long.Parse(Console.ReadLine());
            Console.WriteLine(fibo.Contains(t) ? "IsFibo" : "IsNotFibo");
        }
    }
}