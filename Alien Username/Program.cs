using System;
using System.Text.RegularExpressions;

namespace Alien_Username {
    class Program {
        static void Main(string[] args) {
            var regex = new Regex(@"^(_|\.)[0-9]+[a-zA-Z]*_?$");
            int n = int.Parse(Console.ReadLine());
            while (n-- > 0) {
                string input = Console.ReadLine();
                Console.WriteLine(regex.IsMatch(input) ? "VALID" : "INVALID");
            }
        }
    }
}
