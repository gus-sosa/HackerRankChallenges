using System;
using System.Text.RegularExpressions;

namespace Split_the_Phone_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"^(\d{1,3})([-\s])(\d{1,3})\2(\d{4,10})$");
            int n = int.Parse(Console.ReadLine());
            while (n-- > 0)
            {
                string phone = Console.ReadLine();
                Match m = regex.Match(phone);
                Console.WriteLine($"CountryCode={m.Groups[1]},LocalAreaCode={m.Groups[3]},Number={m.Groups[4]}");
            }
        }
    }
}
