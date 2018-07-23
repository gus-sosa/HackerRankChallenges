using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    static int[,] tripleRecursion(int n, int m, int k)
    {
        int[,] matrix = new int[n, n];
        for (int i = 0; i < n; i++)
            matrix[i, i] = m + k * i;

        for (int i = 0; i < n; i++)
            for (int j = i + 1; j < n; j++)
                matrix[i, j] = matrix[i, j - 1] - 1;

        for (int j = 0; j < n; j++)
            for (int i = j + 1; i < n; i++)
                matrix[i, j] = matrix[i - 1, j] - 1;

        return matrix;
    }

    static void Main(String[] args)
    {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int m = Convert.ToInt32(tokens_n[1]);
        int k = Convert.ToInt32(tokens_n[2]);
        int[,] result = tripleRecursion(n, m, k);
        PrintMatrix(result);
    }

    private static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
