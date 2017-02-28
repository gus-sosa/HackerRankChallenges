using System;
using System.Text.RegularExpressions;

namespace Saying_Hi
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"^[Hh][Ii]\s[^Dd]");
            int n = int.Parse(Console.ReadLine());
            while (n-- > 0)
            {
                string input = Console.ReadLine();
                if (regex.IsMatch(input))
                    Console.WriteLine(input);
            }
        }
    }
}