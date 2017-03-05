using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Detect_HTML_Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            var regexTag = new Regex("(?<=<)\\w+");
            var regexAttributes = new Regex("\\w+((?==(['\"]).*\\2))");
            int n = int.Parse(Console.ReadLine());
            string input = "";
            var builder = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                builder.AppendLine(Console.ReadLine());
            }
            input = builder.ToString();
            var sortedSet = new SortedList<string, SortedSet<string>>();
            foreach (Match m in regexTag.Matches(input))
            {
                string tagAttributesMatched = m.Value;
                if (!sortedSet.ContainsKey(tagAttributesMatched))
                {
                    sortedSet[tagAttributesMatched] = new SortedSet<string>();
                }
                var list = sortedSet[tagAttributesMatched];
                int indexBracket = input.IndexOf('>', m.Index);
                int startIndex = m.Index + m.Length;
                string listAttributes = input.Substring(startIndex, indexBracket - startIndex);
                foreach (Match mAttr in regexAttributes.Matches(listAttributes))
                {
                    string attr = mAttr.Value;
                    if (!list.Contains(attr))
                    {
                        list.Add(attr);
                    }
                }
            }

            foreach (var item in sortedSet)
            {
                var tag = item.Key;
                var attributes = item.Value;
                Console.Write($"{tag}:{(attributes.Count == 0 ? "" : attributes.Aggregate((aggr, i) => $"{aggr},{i}"))}");
                Console.WriteLine();
            }
        }
    }
}
