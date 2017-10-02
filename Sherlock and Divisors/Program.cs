using System;
using System.Collections.Generic;

namespace Sherlock_and_Divisors
{
    class Program
    {
        static List<int> primes = new List<int>();
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                int n = int.Parse(Console.ReadLine());
                IDictionary<int, int> factors = GetFactors(n);
                int numFactorsOf2 = factors.ContainsKey(2) ? factors[2] : 0;
                Console.WriteLine(numFactorsOf2 * MulFactors(factors));
            }
        }

        private static int MulFactors(IDictionary<int, int> factors)
        {
            int mul = 0;
            foreach (var item in factors)
                if (item.Key != 2)
                    mul = mul == 0 ? item.Value + 1 : mul * (item.Value + 1);
            return mul == 0 ? 1 : mul;
        }

        private static IDictionary<int, int> GetFactors(int n)
        {
            var l = new Dictionary<int, int>();
            foreach (int prime in primes)
            {
                int count = 0;
                while (n % prime == 0)
                {
                    count++;
                    n /= prime;
                }
                if (count > 0)
                    l[prime] = count;
            }

            if (n != 1)
            {
                IDictionary<int, int> factors = GetFactors1(n);
                l = MergeDictionaries(l, factors);
                AddPrimes(factors);
            }

            return l;
        }

        private static void AddPrimes(IDictionary<int, int> factors)
        {
            foreach (int prime in factors.Keys)
                if (primes.BinarySearch(prime) < 0)
                {
                    primes.Add(prime);
                    primes.Sort();
                }
        }

        private static Dictionary<int, int> MergeDictionaries(Dictionary<int, int> l, IDictionary<int, int> factors)
        {
            var r = new Dictionary<int, int>(l);
            foreach (var item in factors)
                if (!r.ContainsKey(item.Key))
                    r.Add(item.Key, item.Value);
            return r;
        }

        private static IDictionary<int, int> GetFactors1(int n)
        {
            var f = new Dictionary<int, int>();
            int sqrt = (int)Math.Ceiling(Math.Sqrt(n));
            for (int i = 2; i <= n && i <= sqrt; i++)
            {
                int count = 0;
                while (n % i == 0)
                {
                    count++;
                    n /= i;
                }
                if (count > 0)
                    f[i] = count;
            }

            if (n != 1)
                f.Add(n, 1);

            return f;
        }
    }
}