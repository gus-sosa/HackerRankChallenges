using System;

namespace IsFibo
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            ulong n;
            while (t-- > 0)
            {
                n = ulong.Parse(Console.ReadLine());
                ulong tmp;
                ulong _5nnPlus4 = 5 * n * n + 4;
                ulong _5nnMinus4 = 5 * n * n - 4;
                Console.WriteLine((ulong)((double)Math.Sqrt(_5nnMinus4)) == _5nnMinus4 || (ulong)((double)Math.Sqrt(_5nnPlus4)) == _5nnPlus4 ? "IsFibo" : "IsNotFibo");
            }
        }
    }
}
