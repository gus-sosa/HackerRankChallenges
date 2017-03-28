using System;
using System.Collections.Generic;
class Solution
{
    private static Dictionary<Tuple<int, int>, bool> dict = new Dictionary<Tuple<int, int>, bool>();
    static void Main(String[] args)
    {
        int n = int.Parse(Console.ReadLine());
        while (n-- > 0)
        {
            string cad = Console.ReadLine();
            dict.Clear();
            Palin(cad, 0, cad.Length - 1);
            Console.WriteLine(GetIndexToRemove(cad, 0, cad.Length - 1));
        }
    }

    private static int GetIndexToRemove(string cad, int iStart, int iEnd)
    {
        if (iStart > iEnd || Palin(cad, iStart, iEnd))
            return -1;

        if (cad[iStart] == cad[iEnd])
        {
            int r = GetIndexToRemove(cad, iStart + 1, iEnd - 1);
            if (r != -1)
                return r;
        }

        if (Palin(cad, iStart, iEnd - 1))
            return iEnd;

        if (Palin(cad, iStart + 1, iEnd))
            return iStart;

        return -1;
    }

    private static bool Palin(string cad, int iStart, int iEnd)
    {
        var t = Tuple.Create(iStart, iEnd);
        if (dict.ContainsKey(t))
            return dict[t];

        bool result = true;
        while (iStart < iEnd && result)
            if (result = (cad[iStart] == cad[iEnd]))
            {
                iStart++;
                iEnd--;
            }

        dict[t] = result;
        return result;
    }
}