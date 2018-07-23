using System;
using System.Linq;

namespace Kangaroo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(i => Convert.ToInt32(i)).ToArray();
            int x1 = arr[0], v1 = arr[1], x2 = arr[2], v2 = arr[3];
            Console.WriteLine(v1 > v2 && (x2 - x1) % (v1 - v2) == 0 ? "YES" : "NO");
        }
    }
}
