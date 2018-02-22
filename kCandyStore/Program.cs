using System;
using System.Collections.Generic;

namespace kCandyStore
{
    class Program
    {
        private static int mod = Convert.ToInt32(Math.Pow(10, 9));
        static Dictionary<int, int> map = new Dictionary<int, int>();
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                int n = int.Parse(Console.ReadLine());
                int k = int.Parse(Console.ReadLine());

                Console.WriteLine(GetDistribution(n, k));
            }
        }

        private static int GetDistribution(int n, int k)
        {
            return Combination(n + k - 1, n - 1);
        }

        private static int Combination(int n, int k)
        {
            int combinationCode = GetCode(n, k);
            if (n == 0)
                return 0;
            if (n == k || k == 0)
                return 1;
            if (map.ContainsKey(combinationCode))
                return map[combinationCode];
            return map[combinationCode] = (Combination(n - 1, k - 1) + Combination(n - 1, k)) % mod;
        }

        private static int GetCode(int a, int b)
        {
            return 10000 * a + b;
        }
    }
}