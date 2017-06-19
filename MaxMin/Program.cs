using System;

namespace MaxMin
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int K = int.Parse(Console.ReadLine());
            int[] arr = new int[N];
            for (int i = 0; i < N; i++)
                arr[i] = int.Parse(Console.ReadLine());


            Array.Sort(arr);
            int lowestUnfairness = int.MaxValue;
            int length = N - K;
            for (int i = 0; i <= length; i++)
            {
                int min = arr[i];
                int max = arr[i + K - 1];
                lowestUnfairness = Math.Min(lowestUnfairness, max - min);
            }
            Console.WriteLine(lowestUnfairness);
        }
    }
}
