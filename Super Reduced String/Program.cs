using System;
using System.Collections.Generic;

namespace Super_Reduced_String
{
    class Program
    {
        static IDictionary<string, string> mem = new Dictionary<string, string>() { [""] = "" };
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string result = GetSuperReducedString(s);
            Console.WriteLine(result == "" ? "Empty String" : result);
        }

        private static string GetSuperReducedString(string cad)
        {
            if (mem.ContainsKey(cad))
                return mem[cad];

            string shortestString = cad;
            for (int i = 0; i < cad.Length - 1; i++)
                if (cad[i] == cad[i + 1])
                {
                    string newCad = GetSuperReducedString(cad.Remove(i) + (i + 2 < cad.Length ? cad.Substring(i + 2) : ""));
                    if (newCad.Length < shortestString.Length)
                    {
                        shortestString = newCad;
                        if (shortestString.Length == 0)
                            break;
                    }
                }

            return mem[cad] = shortestString;
        }
    }
}
