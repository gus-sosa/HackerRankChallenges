using System;
using System.Linq;

class Solution
{

    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] a_temp = Console.ReadLine().Split(' ');
        int[] a = a_temp.Select(i => Convert.ToInt32(i)).ToArray();
        Console.WriteLine($"Array is sorted in {Sort(a)} swaps.\nFirst Element: {a[0]}\nLast Element: {a[a.Length - 1]}");
    }

    private static int Sort(int[] a)
    {
        int totalSwaps = 0;
        for (int i = 0; i < a.Length; i++)
        {
            // Track number of elements swapped during a single array traversal
            int numberOfSwaps = 0;

            for (int j = 0; j < a.Length - i - 1; j++)
            {
                // Swap adjacent elements if they are in decreasing order
                if (a[j] > a[j + 1])
                {
                    swap(ref a[j], ref a[j + 1]);
                    numberOfSwaps++;
                }
            }

            // If no elements were swapped during a traversal, array is sorted
            if (numberOfSwaps == 0)
            {
                break;
            }
            totalSwaps += numberOfSwaps;
        }
        return totalSwaps;
    }

    private static void swap(ref int a, ref int b)
    {
        int tmp = a;
        a = b;
        b = tmp;
    }
}