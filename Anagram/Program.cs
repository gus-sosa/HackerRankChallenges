using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    const int LENGTH_DICT = 26;
    const char lastLetter = 'z';
    static int anagram(string s)
    {
        if (s.Length % 2 == 1)
            return -1;

        int[] dict = new int[LENGTH_DICT];
        int halfLength = s.Length / 2;
        for (int i = 0; i < halfLength; i++)
            dict[GetIntegerValue(s[i])]++;

        int count = 0;
        for (int i = halfLength; i < s.Length; i++)
        {
            int pos = GetIntegerValue(s[i]);
            if (dict[pos] == 0)
                count++;
            else
                dict[pos]--;
        }

        return count;
    }

    private static int GetIntegerValue(char v) => lastLetter - v;

    static void Main(String[] args)
    {
        int q = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < q; a0++)
        {
            string s = Console.ReadLine();
            int result = anagram(s);
            Console.WriteLine(result);
        }
    }
}
