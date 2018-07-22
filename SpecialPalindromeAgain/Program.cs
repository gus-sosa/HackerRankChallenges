using System;
using System.Collections.Generic;
using System.Diagnostics;

class Solution
{
    private const char NULL_CHARACTER = '\0';
    // Complete the substrCount function below.
    static long substrCount(string s)
    {
        var map = new Dictionary<int, Dictionary<int, char>>();
        long count = 0;
        //Debugger.Launch();
        for (int i = 0; i < s.Length; i++)
        {
            ++count;
            AddKeyValue(map, Tuple.Create(i, i), s[i]);
            if (i + 1 < s.Length && s[i] == s[i + 1])
            {
                AddKeyValue(map, Tuple.Create(i, i + 1), s[i]);
                ++count;
            }
            if (i + 2 < s.Length && s[i] == s[i + 2])
            {
                AddKeyValue(map, Tuple.Create(i, i + 2), s[i]);
                AddKeyValue(map, Tuple.Create(i + 2, i), s[i + 1]);
                ++count;
            }
        }

        for (int l = 4; l <= s.Length; l++)
            for (int i = 0; i + l - 1 < s.Length; i += l)
            {
                int middleIndex = (i + l) / 2;
                int iStartHead = i,
                    iEndHead = middleIndex - 1,
                    iStartTail = l % 2 == 0 ? middleIndex : middleIndex + 1,
                    iEndTail = i + l - 1;
                var head = Tuple.Create(iStartHead, iEndHead);
                var tail = Tuple.Create(iStartTail, iEndTail);
                var headReverse = Tuple.Create(iEndHead, iStartHead);
                var tailReverse = Tuple.Create(iEndTail, iStartTail);
                if (ContainKey(map, head) && GetValue(map, head) == GetValue(map, tail) &&
                      GetValue(map, headReverse) == NULL_CHARACTER && GetValue(map, headReverse) == GetValue(map, tailReverse))
                {
                    ++count;
                    AddKeyValue(map, Tuple.Create(i, i + l - 1), s[i]);
                    if (l % 2 != 0 && s[middleIndex] != s[i])
                        AddKeyValue(map, Tuple.Create(i + l - 1, i), s[middleIndex]);
                }
            }

        return count;
    }

    private static char GetValue(Dictionary<int, Dictionary<int, char>> map, Tuple<int, int> key)
    {
        var dictionary = map[key.Item1];
        if (dictionary != null && dictionary.ContainsKey(key.Item2))
            return dictionary[key.Item2];
        return NULL_CHARACTER;
    }

    private static bool ContainKey(Dictionary<int, Dictionary<int, char>> map, Tuple<int, int> key)
    {
        var dictionary = map[key.Item1];
        return dictionary != null && dictionary.ContainsKey(key.Item2);
    }

    private static void AddKeyValue(Dictionary<int, Dictionary<int, char>> map, Tuple<int, int> key, char value)
    {
        if (!map.ContainsKey(key.Item1))
            map[key.Item1] = new Dictionary<int, char>();
        map[key.Item1][key.Item2] = value;
    }

    private static char GetCharacter(Dictionary<int[], char> map, int[] positions) { return map.ContainsKey(positions) ? map[positions] : NULL_CHARACTER; }

    static void Main(string[] args)
    {
        Console.ReadLine();//skipping

        string s = Console.ReadLine();

        long result = substrCount(s);

        Console.WriteLine(result);
    }
}
