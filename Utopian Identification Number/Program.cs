using System;
using System.Text.RegularExpressions;

namespace Utopian_Identification_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"^[a-z]{0,3}\d{2,8}[A-Z]{3,}$");
            int n = int.Parse(Console.ReadLine());
            while (n-- > 0)
            {
                string input = Console.ReadLine();
                Console.WriteLine(regex.IsMatch(input) ? "VALID" : "INVALID");
            }
        }
    }
}