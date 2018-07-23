using System;
using System.Linq;

namespace AppleAndOrange
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();
            int s = int.Parse(tokens[0]);
            int t = int.Parse(tokens[1]);
            tokens = Console.ReadLine().Split();
            int a = int.Parse(tokens[0]);
            int b = int.Parse(tokens[1]);
            Console.ReadLine();
            int[] applesInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] orangesInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int countApples = applesInfo.Count(i => a + i >= s && a + i <= t),
                countOranges = orangesInfo.Count(i => b + i >= s && b + i <= t);
            Console.WriteLine(countApples);
            Console.WriteLine(countOranges);
        }
    }
}
