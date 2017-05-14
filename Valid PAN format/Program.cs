using System;
using System.Text.RegularExpressions;

namespace Valid_PAN_format
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var regex = new Regex(@"^[A-Z]{5}\d{4}[A-Z]$");
            while (n-- > 0)
            {
                string input = Console.ReadLine();
                Console.WriteLine(regex.IsMatch(input) ? "YES" : "NO");
            }
        }
    }
}