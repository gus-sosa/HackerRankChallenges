using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYearChaos
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                Console.ReadLine();//skipping the length of the array
                int[] stickers = Console.ReadLine().Split(' ').Select(token => int.Parse(token)).ToArray();

                int result = IsOrdenable(stickers);
                Console.WriteLine(result == -1 ? "Too chaotic" : result.ToString());
            }
        }

        private static int IsOrdenable(int[] stickers)
        {
            int[] counter = new int[stickers.Length];
            int totalBribes = 0;

            for (int i = 0; i < stickers.Length; i++)
                for (int j = i + 1; j < stickers.Length; j++)
                {
                    if (stickers[i] == i + 1)
                        break;

                    if (stickers[j] == i + 1)
                        for (int jj = j; jj > i; jj--)
                        {
                            if (++counter[stickers[jj - 1] - 1] > 2)
                                return -1;
                            swap(stickers, jj, jj - 1);
                            totalBribes++;
                        }
                }

            return totalBribes;
        }

        private static void swap(int[] arr, int i1, int i2)
        {
            int tmp = arr[i1];
            arr[i1] = arr[i2];
            arr[i2] = tmp;
        }
    }
}
