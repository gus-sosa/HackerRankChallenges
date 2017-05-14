using System;
using System.Text;
using System.Text.RegularExpressions;

namespace TheBritishAmericanStyleSpelling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input;
            var builder = new StringBuilder();
            while (n-- > 0)
            {
                builder.AppendLine(Console.ReadLine());
            }
            input = builder.ToString();
            n = int.Parse(Console.ReadLine());
            var regexPrefix = new Regex("\\w+(?=ze)");
            while (n-- > 0)
            {
                string englishWord = Console.ReadLine();
                string prefix = regexPrefix.Match(englishWord).Value;
                Console.WriteLine(new Regex($"{prefix}(ze|se)").Matches(input).Count);
            }
        }
    }
}
