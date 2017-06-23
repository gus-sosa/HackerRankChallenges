using System;
using System.Collections.Generic;

namespace IsFibo
{
    class Program
    {
        static ulong[] table;
        static void Main(string[] args)
        {
            PreCompute();

            int t = int.Parse(Console.ReadLine());
            ulong n;
            while (t-- > 0)
            {
                n = ulong.Parse(Console.ReadLine());
                Console.WriteLine(IsFibo(n) ? "IsFibo" : "IsNotFibo");
            }
        }

        private static bool IsFibo(ulong n)
        {
            int index = Array.BinarySearch(table, n);
            return index > 0;
        }

        private static void PreCompute()
        {
            var list = new List<ulong>() { 0, 1 };
            ulong max = Convert.ToUInt64(Math.Pow(10, 10));
            ulong a = 0;
            ulong b = 1;
            ulong current;
            do
            {
                current = a + b;
                list.Add(current);
                a = b;
                b = current;
            } while (current <= max);
            table = list.ToArray();
        }
    }
}
