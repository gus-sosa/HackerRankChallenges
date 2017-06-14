using System;
using System.Linq;
class Solution
{

    static void Main(String[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            Convert.ToInt32(tokens_n[0]);//skipped
            int k = Convert.ToInt32(tokens_n[1]);
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);
            int[] late = a.Where(studentTimeArrival => studentTimeArrival > 0).ToArray();
            int countStudentnsInClass = a.Length - late.Length;
            Console.WriteLine(countStudentnsInClass >= k ? "NO" : "YES");
        }
    }
}