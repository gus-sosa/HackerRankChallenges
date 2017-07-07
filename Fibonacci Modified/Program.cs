using System;
using System.Numerics;

namespace Fibonacci_Modified
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();
            BigInteger ti, tiPlus1, result = 0;
            BigInteger.TryParse(tokens[0], out ti);
            BigInteger.TryParse(tokens[1], out tiPlus1);
            int n = int.Parse(tokens[2]) - 2;
            while (n-- > 0)
            {
                result = tiPlus1 * tiPlus1 + ti;
                ti = tiPlus1;
                tiPlus1 = result;
            }
            Console.WriteLine(result);
        }
    }
}