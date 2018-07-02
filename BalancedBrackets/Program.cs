using System.Collections.Generic;
using System.Linq;
using System;

class Solution
{
    const string YES = "YES";
    const string NO = "NO";
    static readonly char[] openBrackets = new[] { '(', '[', '{' };
    static readonly Dictionary<char, char> pairBrackets = new Dictionary<char, char>()
    {
        ['('] = ')',
        ['['] = ']',
        ['{'] = '}'
    };
    // Complete the isBalanced function below.
    static string isBalanced(string s)
    {
        var stack = new Stack<char>();
        bool flag = true;
        foreach (char c in s)
        {
            if (openBrackets.Contains(c)) stack.Push(c);
            else
            {
                if (stack.Count == 0)
                {
                    flag = false;
                    break;
                }

                char top = pairBrackets[stack.Pop()];
                if (top != c)
                {
                    flag = false;
                    break;
                }
            }
            flag = stack.Count == 0;
        }
        return flag ? YES : NO;
    }

    static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string s = Console.ReadLine();

            string result = isBalanced(s);

            Console.WriteLine(result);
        }
    }
}