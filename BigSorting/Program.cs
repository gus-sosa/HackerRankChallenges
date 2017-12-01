using System;
using System.Collections.Generic;

class Solution
{

    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] unsorted = new string[n];
        for (int unsorted_i = 0; unsorted_i < n; unsorted_i++)
            unsorted[unsorted_i] = Console.ReadLine();

        Sort(unsorted);
        Print(unsorted);
    }

    private static void Print(string[] unsorted)
    {
        foreach (string s in unsorted)
            Console.WriteLine(s);
    }

    private static void Sort(string[] unsorted)
    {
        int pos = 0;
        Array.Sort(unsorted, new LengthComparer());
        for (int i = 0; i < unsorted.Length; i++)
        {
            int j = i + 1;
            while (j < unsorted.Length && unsorted[j].Length == unsorted[i].Length)
                j++;
            j--;
            if (i < j)
                CountingSort(unsorted, 0, i, j);
            i = j;
        }
    }

    private static void CountingSort(string[] unsorted, int pos, int iStart, int iEnd)
    {
        List<string>[] digits = new List<string>[10];
        for (int i = 0; i < 10; i++)
            digits[i] = new List<string>();

        for (int i = iStart; i <= iEnd; i++)
        {
            int digit = int.Parse(unsorted[i][pos].ToString());
            digits[digit].Add(unsorted[i]);
        }

        int startPos = iStart;
        foreach (List<string> digitSet in digits)
            if (digitSet.Count > 0)
            {
                int endPos = startPos;
                foreach (string s in digitSet)
                    unsorted[endPos++] = s;
                endPos--;
                if (startPos < endPos && pos + 1 < unsorted[startPos].Length)
                    CountingSort(unsorted, pos + 1, startPos, endPos);
                startPos = endPos + 1;
            }
    }
}

internal class LengthComparer : IComparer<string>
{
    public int Compare(string x, string y)
    {
        return x.Length.CompareTo(y.Length);
    }
}
