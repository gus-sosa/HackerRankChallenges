using System;
class Solution
{
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int iTestCases = 0;
        double number = 0;
        iTestCases = Convert.ToInt32(Console.ReadLine().ToString().TrimEnd());
        for (int i = 0; i < iTestCases; i++)
        {
            number = Convert.ToDouble(Console.ReadLine().ToString().TrimEnd());
            Console.WriteLine(IsFib(number));
        }
    }

    static string IsFib(double n)
    {
        if (IsSquare(5 * n * n + 4) || IsSquare(5 * n * n - 4))
            return "IsFibo";
        else
            return "IsNotFibo";
    }

    static bool IsSquare(double n)
    {
        double root = Math.Sqrt(n);
        Int64 iroot = Convert.ToInt64(root);
        if (root - iroot == 0)
            return true;
        else
            return false;
    }
}