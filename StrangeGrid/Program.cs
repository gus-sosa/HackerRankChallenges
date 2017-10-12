using System;

namespace StrangeGrid
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();
            ulong r = ulong.Parse(tokens[0]) - 1;
            ulong c = ulong.Parse(tokens[1]) - 1;
            ulong sum = (ulong)(r % 2 == 0 ? 0 : 1);
            ulong factor = r % 2 == 0 ? r : r - 1;
            Console.WriteLine(5 * factor + 2 * c + sum);
        }
    }
}
