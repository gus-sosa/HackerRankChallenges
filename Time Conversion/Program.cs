using System;
using System.Linq;
using System.Text.RegularExpressions;

class Solution
{

    static void Main(String[] args)
    {
        string time = Console.ReadLine();
        bool am = time.Contains('A');
        string colon_mmss_am = new Regex(@":\d{2}:\d{2}").Match(time).Value;
        int hh = int.Parse(new Regex(@"\d{2}").Matches(time)[0].Value);
        if (am)
        {
            if (hh == 12)
                hh = 0;
        }
        else
        {
            if (hh != 12)
                hh += 12;
        }
        string hh_string = hh.ToString();
        if (hh_string.Length == 1)
            hh_string = "0" + hh_string;
        Console.WriteLine($"{hh_string}{colon_mmss_am}");
    }
}