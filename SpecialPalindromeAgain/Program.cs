using System;
using System.Diagnostics;

class Solution
{
    private const char NULL_CHARACTER = '\0';
    // Complete the substrCount function below.
    static long substrCount(string s)
    {
        var matrix = new char[s.Length, s.Length];
        long count = 0;

        for (int i = 0; i < s.Length; i++)
        {
            ++count;
            matrix[i, i] = s[i];
            if (i + 1 < s.Length && s[i] == s[i + 1])
            {
                matrix[i, i + 1] = s[i];
                ++count;
            }
            if (i + 2 < s.Length && s[i] == s[i + 2])
            {
                matrix[i, i + 2] = s[i];
                matrix[i + 2, i] = s[i + 1];
                ++count;
            }
        }

        Debugger.Launch();

        for (int l = 4; l <= s.Length; l++)
            for (int i = 0; i + l - 1 < s.Length; i += l)
            {
                int middleIndex = (i + l) / 2;
                int iStartHead = i,
                    iEndHead = middleIndex - 1,
                    iStartTail = l % 2 == 0 ? middleIndex : middleIndex + 1,
                    iEndTail = i + l - 1;
                if (matrix[iStartHead, iEndHead] != NULL_CHARACTER && matrix[iStartHead, iEndHead] == matrix[iStartTail, iEndTail] &&
                    matrix[iEndHead, iStartHead] == NULL_CHARACTER && matrix[iEndHead, iStartHead] == matrix[iEndTail, iStartTail])
                {
                    ++count;
                    matrix[i, i + l - 1] = s[i];
                    if (l % 2 != 0 && s[middleIndex] != s[i])
                        matrix[i + l - 1, i] = s[middleIndex];
                }
            }

        return count;
    }

    static void Main(string[] args)
    {
        Console.ReadLine();//skipping

        string s = Console.ReadLine();

        long result = substrCount(s);

        Console.WriteLine(result);
    }
}
