using System;
using System.Text;

class Solution
{
    const string NO_VALUE = "-1";
    const char MAX_DIGIT = '9';
    static string richieRich(string s, int n, int k)
    {
        var parameter = new StringBuilder(s);
        return richieRich(parameter, 0, s.Length - 1, k) ? parameter.ToString() : NO_VALUE;
    }

    private static bool richieRich(StringBuilder s, int i, int j, int k)
    {
        if (k < 0) return false;
        if (i >= j) return true;
        if (s[i] == s[j]) return richieRich(s, i + 1, j - 1, k);

        int si = Convert.ToInt32(s[i]);
        int sj = Convert.ToInt32(s[j]);

        int max = Math.Max(si, sj);
        s[i] = s[j] = Convert.ToChar(max);
        string sol1 = "";
        if (richieRich(s, i + 1, j - 1, k - 1))
            sol1 = s.ToString();

        s[i] = s[j] = MAX_DIGIT;
        string sol2 = "";
        if (richieRich(s, i + 1, j - 1, k - 2))
            sol2 = s.ToString();

        if (string.IsNullOrEmpty(sol1) && string.IsNullOrEmpty(sol2))
        {
            s[i] = Convert.ToChar(si);
            s[j] = Convert.ToChar(sj);
            return false;
        }

        if (Greater(sol1, sol2))
            s = new StringBuilder(sol1);

        return true;
    }

    private static bool Greater(string sol1, string sol2)
    {
        int lengthSol1 = Length(sol1);
        int lengthSol2 = Length(sol2);
        if (lengthSol1 != lengthSol2)
            return lengthSol1 > lengthSol2;

        for (int i = Math.Max(sol1.Length, sol2.Length) - 1, isol1 = 0, isol2 = 0; i < sol1.Length && i < sol2.Length; i++)
        {
            isol1 = sol1.Length - 1 - i;
            isol2 = sol2.Length - 1 - i;
            if (sol1[isol1] == sol2[isol2]) continue;
            else return sol1[isol1] > sol2[isol2];
        }
        return false;
    }

    private static int Length(string cad)
    {
        int i = 0;
        while (i < cad.Length && cad[i] == '0')
            i++;
        return cad.Length - i;
    }

    static void Main(String[] args)
    {
        string[] tokens = Console.ReadLine().Split();
        int n = Convert.ToInt32(tokens[0]);
        int k = Convert.ToInt32(tokens[1]);
        string s = Console.ReadLine();
        string result = richieRich(s, n, k);
        Console.WriteLine(result);
    }
}
