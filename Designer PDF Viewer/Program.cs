using System;
class Solution
{

    static void Main(String[] args)
    {
        int[] h = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
        string word = Console.ReadLine();

        int maxH = -1;

        foreach (char w in word)
            maxH = Math.Max(maxH, h[w - 'a']);

        Console.WriteLine(maxH * word.Length);
    }
}
