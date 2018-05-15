using System;

class Solution
{
    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());

        bool validPoints = true, validHorizontalPoints = true, validVerticalPoints = true;
        string[] token = Console.ReadLine().Split();
        int xPivot = int.Parse(token[0]), yPivot = int.Parse(token[1]);
        for (int nItr = 1; nItr < n && validPoints; nItr++)
        {
            token = Console.ReadLine().Split();
            int x = Convert.ToInt32(token[0]);
            int y = Convert.ToInt32(token[1]);

            validVerticalPoints = validVerticalPoints && x == xPivot;
            validHorizontalPoints = validHorizontalPoints && y == yPivot;
            validPoints = validHorizontalPoints || validVerticalPoints;
        }

        Console.WriteLine(validPoints ? "YES" : "NO");
    }
}