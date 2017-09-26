using System;

namespace Army_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();
            int n = int.Parse(tokens[0]);
            int m = int.Parse(tokens[1]);
            Console.WriteLine(sol(n, m));
        }

        private static int sol(int n, int m)
        {
            if (n == 0 || m == 0)
                return 0;

            if (n > m)
                return sol(m, n);

            if (n == m && n == 1)
                return 1;

            if (n == 1)
                return m / 2 + (m % 2 == 0 ? 0 : 1);

            //n>2
            int countRowSquare = n / 2;
            int countColSquare = m / 2;

            return countRowSquare * countRowSquare + sol(n - countRowSquare * 2, m) + sol(n, m - countColSquare * 2) - (n % 2 != 0 && m % 2 != 0 ? 1 : 0);
        }
    }
}
