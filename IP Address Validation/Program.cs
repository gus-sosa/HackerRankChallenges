using System;
using System.Text.RegularExpressions;

namespace IP_Address_Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var regexIpv4 = new Regex(@"^(([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])$");
            var regexIpv6 = new Regex("^([0-9a-f]{1,4}:){7}[0-9a-f]{1,4}$");
            while (n-- > 0)
            {
                string input = Console.ReadLine();
                Console.WriteLine(regexIpv4.IsMatch(input) ? "IPv4" : (regexIpv6.IsMatch(input) ? "IPv6" : "Neither"));
            }
        }
    }
}