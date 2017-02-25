using System;
using System.Text.RegularExpressions;

namespace HackerRank_Tweets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int count = 0;
            var regex = new Regex("[hH][aA][cC][kK][eE][rR]{2}[aA][nN][kK]");
            while (n-- > 0)
            {
                string input = Console.ReadLine();
                count += regex.Matches(input).Count;
            }
            Console.WriteLine(count);
        }
    }
}