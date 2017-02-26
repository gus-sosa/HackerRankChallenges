using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Build_a_Stack_Exchange_Scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            using (StreamReader sr = new StreamReader(Console.OpenStandardInput()))
            {
                input = sr.ReadToEnd();
            }

            var regexGetQuestionInfo = new Regex("(<a .* class=\"question-hyperlink\">.*</a>|<span .* class=\"relativetime\".*>.*</span>)");
            var regexGetSpanInfo = new Regex("(?<=<span .* class=\"relativetime\".*>).*(?=</span>)");
            var regexGetQuestionInfoId = new Regex("(?<=href=\"/questions/)\\d+");
            var regexGetQuestionInfoAbout = new Regex("(?<=<a.*>).*(?=<\\/a>)");
            string previousValue = "";
            foreach (Match match in regexGetQuestionInfo.Matches(input))
            {
                string currentValue = match.Value;
                if (currentValue.Contains("class=\"relativetime\""))
                {
                    Console.WriteLine($"{previousValue};{regexGetSpanInfo.Match(currentValue).Value}");
                    previousValue = "";
                }
                else
                {
                    string id = regexGetQuestionInfoId.Match(currentValue).Value;
                    string about = regexGetQuestionInfoAbout.Match(currentValue).Value;
                    previousValue = $"{id};{about}";
                }
            }
        }
    }
}