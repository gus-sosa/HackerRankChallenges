using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Solution
{
    static void Main(String[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string input;
        var regExp = new Regex("<\\s*([a-zA-Z]+)(?=(\\s|[a-zA-Z]|[a-zA-Z]\\s*=\\s*\".*\"|[a-zA-Z]\\s*=\\s*'.*')*(.*<\\s*\\/\\1|\\/)\\s*>)");
        var set = new SortedSet<string>();
        while (n-- > 0)
        {
            input = Console.ReadLine();
            foreach (Match match in regExp.Matches(input))
            {
                string currentValue = match.Value.Replace("<", "").Trim();
                if (!set.Contains(currentValue))
                {
                    set.Add(currentValue);
                }
            }
        }
        bool firstPrinted = false;
        foreach (var item in set)
        {
            Console.Write(firstPrinted ? $";{item}" : item);
            if (!firstPrinted)
            {
                firstPrinted = true;
            }
        }
    }
}