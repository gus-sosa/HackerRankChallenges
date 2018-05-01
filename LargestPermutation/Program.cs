using System;
using System.Collections.Generic;
class Solution
{

    static int[] largestPermutation(int k, int[] arr)
    {
        var map = new SortedDictionary<int, int>();
        for (int i = 0; i < arr.Length; i++)
            map[arr[i]] = i;

        for (int i = 0; i < arr.Length && k > 0; i++)
        {
            var index = map[arr.Length - i];
            if (index != i)
            {
                swap(i, index, arr);
                k--;
                map.Remove(arr[i]);
                map[arr[index]] = index;
            }
        }

        return arr;
    }

    private static void swap(int i1, int i2, int[] arr)
    {
        int tmp = arr[i1];
        arr[i1] = arr[i2];
        arr[i2] = tmp;
    }

    static void Main(String[] args)
    {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int k = Convert.ToInt32(tokens_n[1]);
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
        int[] result = largestPermutation(k, arr);
        Console.WriteLine(String.Join(" ", result));
    }
}