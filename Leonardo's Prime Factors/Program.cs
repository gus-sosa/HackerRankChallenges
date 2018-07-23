using System;

namespace Leonardo_s_Prime_Factors
{
    class Program
    {
        static ulong[] primes = new ulong[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53 };
        static void Main(string[] args)
        {
            int q = int.Parse(Console.ReadLine());
            while (q-- > 0)
            {
                ulong n = ulong.Parse(Console.ReadLine());
                int count = 0;
                ulong mul = 2;
                while (mul <= n)
                    mul *= primes[++count];
                Console.WriteLine(count);
            }
        }
    }
}
