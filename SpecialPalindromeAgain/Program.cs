using System;
using System.Collections.Generic;

class Solution
{
    class TupleCharacterLength
    {
        public char Character { get; private set; }
        public int Length { get; private set; }

        public static TupleCharacterLength Create(char c, int len)
        {
            return new TupleCharacterLength()
            {
                Character = c,
                Length = len
            };
        }
    }

    // Complete the substrCount function below.
    static long substrCount(string s)
    {
        var sGroup = CreateGroup(s);
        int count = 0;
        for (int i = 0; i < sGroup.Count; i++)
        {
            int l = sGroup[i].Length;
            count += ComputeNumCombinations(l);
            if (l == 1 && i > 0 && i < sGroup.Count - 1 && sGroup[i - 1].Character == sGroup[i + 1].Character)
            {
                l = Math.Min(sGroup[i - 1].Length, sGroup[i + 1].Length);
                count += l;
            }
        }
        return count;
    }

    private static int ComputeNumCombinations(int l) => l * (l + 1) / 2;

    private static List<TupleCharacterLength> CreateGroup(string s)
    {
        var sGroup = new List<TupleCharacterLength>();

        for (int i = 0, j; i < s.Length;)
        {
            j = i + 1;
            while (j < s.Length && s[i] == s[j])
                j++;
            int lengthGroup = j - i;
            sGroup.Add(TupleCharacterLength.Create(s[i], lengthGroup));
            i = j;
        }
        return sGroup;
    }

    static void Main(string[] args)
    {
        Console.ReadLine();//skipping

        string s = Console.ReadLine();

        long result = substrCount(s);

        Console.WriteLine(result);
    }
}