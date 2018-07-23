using System;

namespace Minimum_Height_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();
            float b = float.Parse(tokens[0]);
            int a = int.Parse(tokens[1]);
            Console.WriteLine((int)Math.Ceiling(2 * a / b));
        }
    }
}
