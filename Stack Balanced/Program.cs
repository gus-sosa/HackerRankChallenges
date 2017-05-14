using System;
using System.Collections.Generic;
class Solution {

    static void Main(String[] args) {
        int t = Convert.ToInt32(Console.ReadLine());
        Stack<char> stack = new Stack<char>();
        for (int a0 = 0; a0 < t; a0++) {
            string expression = Console.ReadLine();
            stack.Clear();
            bool flag = true;
            for (int i = 0; flag && i < expression.Length; i++) {
                char c = expression[i];
                switch (c) {
                    case '(':
                    case '{':
                    case '[':
                        stack.Push(c);
                        break;
                    default://close symbol:  )  }  ]
                        if (stack.Count == 0) {
                            flag = false;
                        } else {
                            var top = stack.Pop();
                            flag = (top == '(' && c == ')') ||
                                    (top == '[' && c == ']') ||
                                    (top == '{' && c == '}');
                        }
                        break;
                }
            }
            Console.WriteLine(flag && stack.Count == 0 ? "YES" : "NO");
        }
    }
}