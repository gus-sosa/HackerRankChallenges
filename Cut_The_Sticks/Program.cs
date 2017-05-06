using System;

namespace Cut_The_Sticks
{
    class Program
    {
        static int[] arr;
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            arr = new int[N];
            string[] tokens = Console.ReadLine().Split();
            for (int i = 0; i < N; i++)
                arr[i] = int.Parse(tokens[i]);

            while (N > 0)
            {
                Console.WriteLine(N);
                Tuple<int, int> minTuple = GetMinAndCountMin();
                int min = minTuple.Item1;
                int minCount = minTuple.Item2;

                int[] newArr = new int[N - minCount];
                for (int i = 0, lastPos = -1; i < newArr.Length; i++)
                {
                    for (int j = lastPos + 1; j < arr.Length; j++)
                    {
                        int current = arr[j];
                        if (current == min) continue;
                        else
                        {
                            newArr[i] = current - min;
                            lastPos = j;
                            break;
                        }
                    }
                }

                arr = newArr;
                N = newArr.Length;
            }
        }

        private static Tuple<int, int> GetMinAndCountMin()
        {
            int min = -1, count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (count == 0 || arr[i] < min)
                {
                    min = arr[i];
                    count = 1;
                }
                else if (arr[i] == min) count++;
            }
            return Tuple.Create(min, count);
        }
    }
}