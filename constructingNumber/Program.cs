using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    static string canConstruct(int[] a)
    {
        int sum = 0;
        foreach (int num in a)
        {
            int n = num;
            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }
        }
        return sum % 3 == 0 ? "Yes" : "No";
    }

    static void Main(String[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);
            string result = canConstruct(a);
            Console.WriteLine(result);
        }
    }
}
