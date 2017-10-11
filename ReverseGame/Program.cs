using System;

namespace ReverseGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                string[] tokens = Console.ReadLine().Split();
                int n = int.Parse(tokens[0]);
                int k = int.Parse(tokens[1]);
                int half = n / 2;
                Console.WriteLine(k >= half ? (2 * (n - 1 - k)) : (2 * k + 1));
            }
        }
    }
}
