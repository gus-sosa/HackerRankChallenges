using System;
class Solution
{
    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[][] a = new int[n][];
        for (int a_i = 0; a_i < n; a_i++)
        {
            string[] a_temp = Console.ReadLine().Split(' ');
            a[a_i] = Array.ConvertAll(a_temp, Int32.Parse);
        }

        int sumFirstDiag = 0, sumSecondDiag = 0;
        for (int i = 0; i < n; i++)
        {
            sumFirstDiag += a[i][i];
            sumSecondDiag += a[i][n - i - 1];
        }
        Console.WriteLine(Math.Abs(sumFirstDiag - sumSecondDiag));
    }
}
