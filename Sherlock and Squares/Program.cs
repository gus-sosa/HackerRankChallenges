namespace Sherlock_and_Squares
{
    using System;
    class Program
    {
        const int MAX_LENGTH = 31622 + 1;
        static int[] arr = new int[MAX_LENGTH];

        static int GetCount(int a, int b)
        {
            int low = (int)Math.Ceiling(Math.Sqrt(a)), high = (int)Math.Floor(Math.Sqrt(b));
            return high - low + 1;
        }

        static void PreCompute()
        {
            for (int i = 0; i < MAX_LENGTH; i++)
                arr[i] = i * i;
        }

        static void Main(string[] args)
        {
            PreCompute();

            int t, a, b;
            t = int.Parse(Console.ReadLine());
            for (; t > 0; t--)
            {
                string[] tokens = Console.ReadLine().Split();
                a = int.Parse(tokens[0]);
                b = int.Parse(tokens[1]);
                Console.WriteLine(GetCount(a, b));
            }
        }
    }
}