using System;

namespace Maximum_Draws
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(n + 1);
            }
        }
    }
}