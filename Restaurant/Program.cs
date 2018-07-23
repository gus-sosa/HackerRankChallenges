using System;

namespace Restaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                string[] tokens = Console.ReadLine().Split();
                int l = int.Parse(tokens[0]);
                int b = int.Parse(tokens[1]);
                int sideLength = mcd(l, b);
                Console.WriteLine((l * b) / (sideLength * sideLength));
            }
        }

        private static int mcd(int a, int b)
        {
            if (a < b)
                return mcd(b, a);
            if (b == 0)
                return a;
            return mcd(b, a % b);
        }
    }
}
