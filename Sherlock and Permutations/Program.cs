using System;

namespace Sherlock_and_Permutations
{
    class Program
    {
        const ulong mod = 1000000007;
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
                ulong m = ulong.Parse(tokens[1]);
                Console.WriteLine(GetPermutations(n, m));
            }
        }

        private static ulong GetPermutations(ulong n, ulong m)
        {
            return (fact[n + m - 1] * (modular_exp((fact[n] * fact[m - 1]) % mod, mod - 2))) % mod;
        }

        private static ulong modular_exp(ulong num, ulong pow)
        {
            if (pow == 0)
                return 1;
            if (pow == 1)
                return num % mod;

            ulong module = modular_exp(num, pow / 2);
            ulong tmp = (module * module) % mod;

            if (pow % 2 == 0)
                return tmp;

            return (num * tmp) % mod;
        }

        private static void PreComputeFactorials()
        {
            fact[0] = fact[1] = 1;
            for (int i = 2; i < fact.Length; i++)
                fact[i] = (Convert.ToUInt64(i) * fact[i - 1]) % mod;
        }
    }
}