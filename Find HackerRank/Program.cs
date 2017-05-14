using System;
using System.Text.RegularExpressions;

namespace Find_HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            var regexStart = new Regex("^hackerrank");
            var regexEnd = new Regex("hackerrank$");
            int n = int.Parse(Console.ReadLine());

            while (n-- > 0)
            {
                string input = Console.ReadLine();
                bool start = regexStart.IsMatch(input);
                bool end = regexEnd.IsMatch(input);
                Console.WriteLine(start ? (end ? 0 : 1) : (end ? 2 : -1));
            }
        }
    }
}