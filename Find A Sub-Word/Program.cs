using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Find_A_Sub_Word {
    class Program {
        static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine());
            List<string> sentences = new List<string>();
            while (n-- > 0) {
                sentences.Add(Console.ReadLine());
            }
            int q = int.Parse(Console.ReadLine());
            while (q-- > 0) {
                string input = Console.ReadLine();
                n = 0;
                var regex = new Regex($"[_0-9a-zA-Z]{input}[_0-9a-zA-Z]");
                foreach (var sentence in sentences) {
                    n += regex.Matches(sentence).Count;
                }
                Console.WriteLine(n);
            }
        }
    }
}
