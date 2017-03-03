using System;
using System.Text.RegularExpressions;
using System.Linq;

class Solution
{
    static void Main(String[] args)
    {
        string languages = "^C$:CPP:JAVA:PYTHON:PERL:PHP:RUBY:CSHARP:HASKELL:CLOJURE:BASH:SCALA:ERLANG:CLISP:LUA:BRAINFUCK:JAVASCRIPT:GO:D:OCAML:R:PASCAL:SBCL:DART:GROOVY:OBJECTIVEC";
        var regex = new Regex(languages.Split(':').Aggregate((ag, i) => $"{ag}|^{i}$"));
        int n = int.Parse(Console.ReadLine());
        while (n-- > 0)
        {
            string lang = Console.ReadLine().Split(' ')[1];
            Console.WriteLine(regex.IsMatch(lang) ? "VALID" : "INVALID");
        }
    }
}