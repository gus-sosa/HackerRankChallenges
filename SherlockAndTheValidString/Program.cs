using System;

class Solution
{
    private const int LENGTH_ALPHABET = 26;
    private const char A = 'a';

    private const string YES = "YES";
    private const string NO = "NO";
    // Complete the isValid function below.
    static string isValid(string s)
    {
        var alphabetCounter = new int[LENGTH_ALPHABET];
        foreach (char c in s)
            alphabetCounter[c - A]++;

        if (Balanced(alphabetCounter))
            return YES;

        for (int i = 0; i < LENGTH_ALPHABET; i++)
            if (alphabetCounter[i] > 0)
            {
                alphabetCounter[i]--;
                if (Balanced(alphabetCounter))
                    return YES;
                alphabetCounter[i]++;
            }

        return NO;
    }

    private static bool Balanced(int[] alphabetCounter)
    {
        int v = -1;
        foreach (int i in alphabetCounter)
            if (i != 0 && i - v != 0)
                if (v == -1) v = i;
                else return false;
        return true;
    }

    static void Main(string[] args)
    {
        string s = Console.ReadLine();

        string result = isValid(s);

        Console.WriteLine(result);
    }
}
