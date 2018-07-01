using System.IO;
using System;

class Solution
{

    // Complete the minimumSwaps function below.
    static int minimumSwaps(int[] arr)
    {
        int num = 0;

        for (int i = 0; i < arr.Length; i++)
            if (arr[i] != i + 1)
                for (int j = i + 1; j < arr.Length; j++)
                    if (arr[j] == i + 1)
                    {
                        swap(arr, i, j);
                        num++;
                    }

        return num;
    }

    private static void swap(int[] arr, int i, int j)
    {
        int tmp = arr[i];
        arr[i] = arr[j];
        arr[j] = tmp;
    }

    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int res = minimumSwaps(arr);

        Console.WriteLine(res);
    }
}