using System;
class Solution {

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
        Array.Sort(a);
        int minDiff = int.MaxValue;
        for (int i = 0; minDiff != 0 && i < a.Length - 1; i++) {
            minDiff = Math.Min(minDiff, Math.Abs(a[i] - a[i + 1]));
        }
        Console.WriteLine(minDiff);
    }
}