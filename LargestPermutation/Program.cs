using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    static int[] largestPermutation(int k, int[] arr)
    {
        // Complete this function
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