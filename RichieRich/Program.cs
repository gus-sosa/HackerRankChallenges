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
        if (i > j) return true;

        int si = Convert.ToInt32(s[i]);
        int sj = Convert.ToInt32(s[j]);

        if (s[i] != '9' && s[j] != '9')
        {
            s[i] = s[j] = MAX_DIGIT;
            if (richieRich(s, i + 1, j - 1, i == j ? k - 1 : k - 2))
                return true;
            s[i] = Convert.ToChar(si);
            s[j] = Convert.ToChar(sj);
        }

        if (s[i] == s[j])
            return richieRich(s, i + 1, j - 1, k);

        int max = Math.Max(si, sj);
        s[i] = s[j] = Convert.ToChar(max);
        if (richieRich(s, i + 1, j - 1, k - 1))
            return true;

        s[i] = Convert.ToChar(si);
        s[j] = Convert.ToChar(sj);

        return false;
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
