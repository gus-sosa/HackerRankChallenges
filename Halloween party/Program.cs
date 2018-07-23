using System;

namespace Halloween_party
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                ulong k = ulong.Parse(Console.ReadLine());
                Console.WriteLine(k / 2 * (k - k / 2));
            }
        }
    }
}