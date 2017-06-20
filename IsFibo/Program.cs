using System;
using System.Collections.Generic;

namespace IsFibo
{
    class Program
    {
        static HashSet<ulong> fiboTable = new HashSet<ulong>();
        static void Main(string[] args)
        {
            BuildFiboTable();

            int t = int.Parse(Console.ReadLine());
            ulong n;
            while (t-- > 0)
            {
                n = ulong.Parse(Console.ReadLine());
                Console.WriteLine(fiboTable.Contains(n) ? "IsFibo" : "IsNotFibo");
            }
        }

        private static void BuildFiboTable()
        {
            fiboTable.Add(0);
            fiboTable.Add(1);
            ulong a = 0;
            ulong b = 1;
            ulong len = (ulong)Math.Pow(10, 10);
            for (ulong i = 0; i < len; i++)
            {
                ulong result = a + b;
                a = b;
                b = result;
                fiboTable.Add(result);
            }
        }
    }
}
