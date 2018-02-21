using System;

namespace Sherlock_and_Permutations
{
    class Program
    {
        const ulong mod1 = 1000000007;
        const ulong mod2 = 1000000000000;
        const int maxLength = 2001;
        private static ulong[] fact = new ulong[maxLength];
        static void Main(string[] args)
        {
            PreComputeFactorials();
            int t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                string[] tokens = Console.ReadLine().Split();
                ulong n = ulong.Parse(tokens[0]);
                ulong m = ulong.Parse(tokens[1]) - 1;
                Console.WriteLine(GetPermutations(n, m));
            }
        }

        private static ulong GetPermutations(ulong n, ulong m) { return (fact[n + m] / (fact[n] * fact[m])) % mod1; }

        private static void PreComputeFactorials()
        {
            fact[0] = fact[1] = 1;
            for (int i = 2; i < fact.Length; i++)
                fact[i] = (Convert.ToUInt64(i) * fact[i - 1]) % mod2;
        }
    }
}
