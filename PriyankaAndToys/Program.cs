using System;
class Solution
{

    static int toys(int[] w)
    {
        Array.Sort(w);
        int count = 1, until = w[0] + 4;
        for (int i = 0; i < w.Length; i++)
            if (w[i] > until)
            {
                count += 1;
                until = w[i] + 4;
            }
        return count;
    }

    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] w_temp = Console.ReadLine().Split(' ');
        int[] w = Array.ConvertAll(w_temp, Int32.Parse);
        int result = toys(w);
        Console.WriteLine(result);
    }
}
