using System.Collections.Generic;
using System.Text;
using System;

class Solution
{
    static Dictionary<int, int> map = new Dictionary<int, int>();

    private static string s1, s2;
    // Complete the commonChild function below.
    static int commonChild(int is1, int is2)
    {
        if (is1 == s1.Length || is2 == s2.Length)
            return 0;

        int num = GetIndex(is1, is2);
        if (map.ContainsKey(num))
            return map[num];
        string longestPrefix = GetLongestPrefix(is1, is2);
        return map[num] = longestPrefix.Length == 0
            ? Math.Max(commonChild(is1 + 1, is2), commonChild(is1, is2 + 1))
            : longestPrefix.Length + commonChild(is1 + longestPrefix.Length, is2 + longestPrefix.Length);
    }

    private static string GetLongestPrefix(int is1, int is2)
    {
        var prefix = new StringBuilder();
        while (is1 < s1.Length && is2 < s2.Length && s1[is1] == s2[is2++])
            prefix.Append(s1[is1++]);
        return prefix.ToString();
    }

    private static int GetIndex(int is1, int is2) => is1 * 10000 + is2;

    static void Main(string[] args)
    {
        s1 = Console.ReadLine();
        s2 = Console.ReadLine();
        int result = commonChild(0, 0);
        Console.WriteLine(result);
    }
}
