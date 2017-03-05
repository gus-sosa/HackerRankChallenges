using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UK_US
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
            var regex = new Regex("our");
            while (n-- > 0)
            {
                string britishWord = Console.ReadLine();
                string regexAmerican = regex.Split(britishWord).Aggregate((agg, i) => $"{agg}or{i}");
                Console.WriteLine(new Regex($@"\b({britishWord}|{regexAmerican})\b").Matches(input).Count);
            }
        }
    }
}
