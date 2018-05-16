using System;
using System.IO;

class Solution
{

    // Complete the solve function below.
    static long solve(int[][] steps)
    {
        long minx = long.MaxValue, miny = long.MaxValue;
        foreach (int[] step in steps)
        {
            minx = Math.Min(minx, step[0]);
            miny = Math.Min(miny, step[1]);
        }
        return minx * miny;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[][] steps = new int[n][];

        for (int stepsRowItr = 0; stepsRowItr < n; stepsRowItr++)
        {
            steps[stepsRowItr] = Array.ConvertAll(Console.ReadLine().Split(' '), stepsTemp => Convert.ToInt32(stepsTemp));
        }

        long result = solve(steps);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}