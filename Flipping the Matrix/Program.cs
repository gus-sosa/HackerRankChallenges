using System;

namespace Flipping_the_Matrix
{
    class Program
    {
        const int LengthMatrix = 256;
        static void Main(string[] args)
        {
            int q = int.Parse(Console.ReadLine());
            int n;
            int[,] matrix = new int[LengthMatrix, LengthMatrix];
            while (q-- > 0)
            {
                n = 2 * int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    string[] tokens = Console.ReadLine().Split();
                    for (int j = 0; j < n; j++)
                        matrix[i, j] = int.Parse(tokens[j]);
                }

                Console.WriteLine(MaxSum(matrix, n));
            }
        }

        private static int MaxSum(int[,] matrix, int n)
        {
            int maxSum = 0;
            int lengthFirstQuadrant = n / 2;
            for (int i = 0; i < lengthFirstQuadrant; i++)
                for (int j = 0; j < lengthFirstQuadrant; j++)
                    maxSum += Math.Max(matrix[i, j], Math.Max(matrix[n - i - 1, j], Math.Max(matrix[i, n - j - 1], matrix[n - i - 1, n - j - 1])));

            return maxSum;
        }
    }
}