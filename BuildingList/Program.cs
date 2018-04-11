using System;
using System.Collections.Generic;

namespace BuildingList
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                int n = int.Parse(Console.ReadLine());
                char[] set = Console.ReadLine().ToCharArray();

                var pivote = (int)Math.Pow(2, n) - 1;
                var orderSet = new SortedSet<string>();
                while (pivote > 0)
                    orderSet.Add(GetCad(set, pivote--));

                foreach (string s in orderSet)
                    Console.WriteLine(s);
            }
        }

        private static string GetCad(char[] set, int pivote)
        {
            string r = "";
            foreach (char t in set)
            {
                if ((pivote & 1) == 1)
                    r += t;
                pivote >>= 1;
            }
            return r;
        }
    }
}