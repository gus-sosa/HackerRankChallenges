using System;

class Solution
{

    static int surfaceArea(int[][] A, int rows, int cols)
    {
        int result = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result += 2 + 4 * A[i][j];
                if (i > 0)
                    result -= 2 * Math.Min(A[i][j], A[i - 1][j]);
                if (j > 0)
                    result -= 2 * Math.Min(A[i][j], A[i][j - 1]);
            }
        }

        return result;
    }

    static void Main(String[] args)
    {
        string[] tokens_H = Console.ReadLine().Split(' ');
        int H = Convert.ToInt32(tokens_H[0]);
        int W = Convert.ToInt32(tokens_H[1]);
        int[][] A = new int[H][];
        for (int A_i = 0; A_i < H; A_i++)
        {
            string[] A_temp = Console.ReadLine().Split(' ');
            A[A_i] = Array.ConvertAll(A_temp, Int32.Parse);
        }
        int result = surfaceArea(A, H, W);
        Console.WriteLine(result);
    }
}
