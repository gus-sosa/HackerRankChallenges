namespace Sherlock_and_Squares
{
    using System;
    class Program
    {
        const int MAX_LENGTH = 31622 + 1;
        static int[] arr = new int[Program.MAX_LENGTH];

        static int GetCount(int a, int b)
        {
            int low = (int)Math.Ceiling(Math.Sqrt(a)), high = (int)Math.Floor(Math.Sqrt(b));
            bool flag = false;
            while (high < MAX_LENGTH && arr[high] <= b)
            {
                flag = true;
                high++;
            }
            if (flag)
            {
                high--;
                flag = false;
            }
            while (low >= 0 && arr[low] >= a)
            {
                flag = true;
                low--;
            }
            if (flag)
                low++;

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
            while (t-- > 0)
            {
                string[] tokens = Console.ReadLine().Split();
                a = int.Parse(tokens[0]);
                b = int.Parse(tokens[1]);
                Console.WriteLine(GetCount(a, b));
            }
        }
    }
}