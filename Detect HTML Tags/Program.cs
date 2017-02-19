using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Solution
{
    static void Main(String[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string input;
        var regExp = new Regex("(?<=<\\s*)\\w+");
        var set = new SortedSet<string>();
        while (n-- > 0)
        {
            input = Console.ReadLine();
            foreach (Match match in regExp.Matches(input))
            {
                if (!set.Contains(match.Value))
                {
                    set.Add(match.Value);
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