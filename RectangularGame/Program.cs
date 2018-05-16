using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{

    // Complete the solve function below.
    static int solve(int[][] steps)
    {


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

        int result = solve(steps);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
