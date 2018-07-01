using System.IO;
using System;

class Solution
{
    const int rowLength = 6, colLength = 6;
    // Complete the hourglassSum function below.
    static int hourglassSum(int[][] arr)
    {
        int maxSum = int.MinValue;
        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < arr[i].Length; j++)
            {
                int? sumCurrentPattern = GetSumPattern(arr, i, j);
                if (sumCurrentPattern.HasValue)
                    maxSum = Math.Max(maxSum, sumCurrentPattern.Value);
            }
        }
        return maxSum;
    }

    private static int? GetSumPattern(int[][] arr, int row, int col)
    {
        return row + 2 < rowLength && col + 2 < colLength ? (int?)(arr[row][col] + arr[row][col + 1] + arr[row][col + 2] +
            arr[row + 1][col + 1] + arr[row + 2][col] + arr[row + 2][col + 1] + arr[row + 2][col + 2]) : null;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int[][] arr = new int[6][];

        for (int i = 0; i < 6; i++)
        {
            arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        }

        int result = hourglassSum(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
