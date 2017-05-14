using System;
class Solution
{

    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        for (int i = 1; i <= n; i++)
            Console.WriteLine(new string(' ', n - i) + new string('#', i));
    }
}