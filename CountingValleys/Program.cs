using System;

internal class Solution
{
    protected internal const char DOWN = 'D';

    // Complete the countingValleys function below.
    private static int countingValleys(int n, string s)
    {
        int currentLevel = 0, numValleys = 0;
        foreach (var step in s)
            if (step == DOWN)
            {
                if (currentLevel == 0)
                    numValleys++;
                currentLevel--;
            }
            else currentLevel++;
        return numValleys;
    }

    private static void Main(string[] args)
    {
        var n = Convert.ToInt32(Console.ReadLine());
        var s = Console.ReadLine();
        var result = countingValleys(n, s);
        Console.WriteLine(result);
    }
}