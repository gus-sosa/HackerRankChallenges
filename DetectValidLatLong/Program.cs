using System;
using System.Text.RegularExpressions;

namespace DetectValidLatLong
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var regex = new Regex(@"^\([-\+]?([0-9](\.[0-9]+)?|[1-8][0-9](\.[0-9]+)?|90(\.0+)?), [-\+]?([0-9](\.[0-9]+)?|[1-9][0-9](\.[0-9]+)?|1[0-7][0-9](\.[0-9]+)?|180(\.0+)?)\)$");
            while (n-- > 0)
            {
                string input = Console.ReadLine();
                Console.WriteLine(regex.IsMatch(input) ? "Valid" : "Invalid");
            }
        }
    }
}