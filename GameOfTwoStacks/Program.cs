using System;
using System.Collections.Generic;

class Solution {

  class CurrentSumInfo {
    public int Sum { get; set; }
    public int LastNumberAdded { get; set; }
    public bool StackA { get; set; }
  }
  static int twoStacks(int x, Stack<int> a, Stack<int> b)
  {
    //Debugger.Launch();
    var sums = new Stack<CurrentSumInfo>();
    int maxNum = 0;
    do
    {
      if (MoveElement(a, sums, true, x) || MoveElement(b, sums, false, x))
      {
        continue;
      }

      maxNum = Math.Max(maxNum, sums.Count);
      RemoveElement(sums, a, b, x);
    }
    while (sums.Count > 0);
    return maxNum;
  }

  private static void RemoveElement(Stack<CurrentSumInfo> sums, Stack<int> a, Stack<int> b, int x)
  {
    bool flag = false;
    while (!flag)
    {
      var removedElement = sums.Pop();
      if (removedElement.StackA)
      {
        a.Push(removedElement.LastNumberAdded);
        if (MoveElement(b, sums, false, x))
        {
          flag = true;
        }
      }
      else
      {
        b.Push(removedElement.LastNumberAdded);
      }

      flag = flag || sums.Count == 0;
    }
  }

  private static bool MoveElement(Stack<int> stack, Stack<CurrentSumInfo> sums, bool stackA, int x)
  {
    if (stack.Count > 0)
    {
      if (sums.Count > 0)
      {
        if (sums.Peek().Sum - stack.Peek() >= 0)
        {
          var top= sums.Peek();
          int newNum = stack.Pop();
          sums.Push(new CurrentSumInfo() { LastNumberAdded = newNum, StackA = stackA, Sum = top.Sum - newNum });
          return true;
        }
      }
      else
      {
        if (stack.Peek() <= x)
        {
          int num = stack.Pop();
          sums.Push(new CurrentSumInfo() { LastNumberAdded = num, StackA = stackA, Sum = x - num });
          return true;
        }
      }
    }
    return false;
  }

  private static Stack<int> GiveMeStack(int[] arrayStack)
  {
    Stack<int> stack = new Stack<int>();
    for (int i = arrayStack.Length - 1; i >= 0; i--)
    {
      stack.Push(arrayStack[i]);
    }

    return stack;
  }

  static void Main(string[] args)
  {
    int g = Convert.ToInt32(Console.ReadLine());

    for (int gItr = 0; gItr < g; gItr++)
    {
      string[] nmx = Console.ReadLine().Split(' ');

      int n = Convert.ToInt32(nmx[0]);

      int m = Convert.ToInt32(nmx[1]);

      int x = Convert.ToInt32(nmx[2]);

      Stack<int> a = GiveMeStack(Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp)))
      ;

      Stack<int> b = GiveMeStack(Array.ConvertAll(Console.ReadLine().Split(' '), bTemp => Convert.ToInt32(bTemp)))
      ;
      int result = twoStacks(x, a, b);

      Console.WriteLine(result);
    }
  }
}