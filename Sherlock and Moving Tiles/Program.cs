using System;

namespace Sherlock_and_Moving_Tiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();
            long l = long.Parse(tokens[0]);
            long s1 = long.Parse(tokens[1]);
            long s2 = long.Parse(tokens[2]);
            long t;
            if (s2 > s1)
            {
                t = s1;
                s1 = s2;
                s2 = t;
            }

            double factor = Math.Sqrt(2) / (s2 - s1);
            t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                long q = long.Parse(Console.ReadLine());
                Console.WriteLine("{0:F4}", factor * (Math.Sqrt(q) - l));
            }
        }
    }
}
