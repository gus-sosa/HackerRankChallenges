//#define LAUNCH_DEBUGGER

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

class Solution
{
    const string NO_VALUE = "-1";
    const char MAX_DIGIT = '9';
    static string richieRich(string s, int n, int k)
    {
        var cad = new StringBuilder(s);
        int[] result = MakeItPalindrome(cad);
        int changesMade = result[0];
        int[] posChanged = new int[result.Length - 1];
        Array.Copy(result, 1, posChanged, 0, result.Length - 1);

        if (k < changesMade)
            return NO_VALUE;
        if (k == changesMade)
            cad.ToString();

        int i = 0, j = cad.Length - 1;
        for (; i < j; i++, j--)
        {
            if (cad[i] == MAX_DIGIT)
                continue;

            bool wasChanged = posChanged.Length > 0 && Array.BinarySearch(posChanged, i) >= 0;
            if (wasChanged)
            {
                if (k < changesMade + 1)
                    break;

                changesMade++;
            }
            else
            {
                if (k < changesMade + 2)
                    continue;

                changesMade += 2;
            }

            cad[i] = cad[j] = MAX_DIGIT;
        }

        if (cad.Length % 2 != 0 && cad[cad.Length / 2] != MAX_DIGIT && k >= changesMade + 1)
        {
            cad[cad.Length / 2] = MAX_DIGIT;
            changesMade++;
        }

        return cad.ToString();
    }

    private static int[] MakeItPalindrome(StringBuilder s)
    {
        int changes = 0;
        var result = new List<int>() { 0 };
        for (int i = 0, j = s.Length - 1; i < j; i++, j--)
            if (s[i] != s[j])
            {
                var iInt = Convert.ToInt32(s[i]);
                var jInt = Convert.ToInt32(s[j]);
                s[i] = s[j] = Convert.ToChar(Math.Max(iInt, jInt));
                result.Add(i);
                changes++;
            }
        result[0] = changes;
        return result.ToArray();
    }

    static void Main(String[] args)
    {
#if LAUNCH_DEBUGGER
        Debugger.Launch();
#endif
        string[] tokens = Console.ReadLine().Split();
        int n = Convert.ToInt32(tokens[0]);
        int k = Convert.ToInt32(tokens[1]);
        string s = Console.ReadLine();
        string result = richieRich(s, n, k);
        Console.WriteLine(result);
    }
}
