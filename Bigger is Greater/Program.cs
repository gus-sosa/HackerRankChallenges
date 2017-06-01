using System;
using System.Collections.Generic;
using System.Text;

namespace Bigger_is_Greater
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                string word = Console.ReadLine();
                string bestWord = null;
                foreach (string permutation in GetPermutations(word))
                    if (permutation.CompareTo(word) > 0 && (bestWord == null || bestWord.CompareTo(permutation) > 0))
                        bestWord = permutation;
                Console.WriteLine(bestWord ?? "no answer");
            }
        }

        private static IEnumerable<string> GetPermutations(string word)
        {
            var marked = new bool[word.Length];
            var builder = new StringBuilder();
            foreach (string permutation in GetPermutations(word, builder, marked))
                yield return permutation;
        }

        private static IEnumerable<string> GetPermutations(string word, StringBuilder builder, bool[] marked)
        {
            if (builder.Length == word.Length)
                yield return builder.ToString();
            else
                for (int i = 0; i < marked.Length; i++)
                    if (!marked[i])
                    {
                        marked[i] = true;
                        builder.Append(word[i]);
                        foreach (string permutation in GetPermutations(word, builder, marked))
                            yield return permutation;
                        marked[i] = false;
                        builder.Remove(builder.Length - 1, 1);
                    }
        }
    }
}