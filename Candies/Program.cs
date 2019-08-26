using System.Collections.Generic;
using System.Linq;
using System;
using System.Diagnostics;

class Solution
{
  // Complete the candies function below.
  static long candies(int n, int[] arr) {
    long[] candies = Enumerable.Repeat(1L, arr.Length).ToArray();
    var stack = new Stack<int>();
    for (int i = 1; i < arr.Length; ++i) {
      long current = arr[i], previous = arr[i - 1];
      if (current < previous) {
        if (stack.Count == 0) {
          stack.Push(i - 1);
        }
        stack.Push(i);
      } else if (current > previous) {
        CleanStack(arr, candies, stack);
        candies[i] = Math.Max(candies[i], candies[i - 1]) + 1;
      } else {
        CleanStack(arr, candies, stack);
      }
    }

    CleanStack(arr, candies, stack);

    return candies.Sum();
  }

  private static void CleanStack(int[] arr, long[] candies, Stack<int> stack) {
    if (stack.Count > 0) {
      stack.Pop();
      while (stack.Count > 0) {
        var pos = stack.Pop();
        if (arr[pos] > arr[pos + 1] && candies[pos] <= candies[pos + 1]) {
          candies[pos] = candies[pos + 1] + 1;
        }
      }
    }
  }

  static void Main(string[] args) {
    //Debugger.Launch();
    int n = Convert.ToInt32(Console.ReadLine());

    int[] arr = new int[n];

    for (int i = 0; i < n; i++) {
      int arrItem = Convert.ToInt32(Console.ReadLine());
      arr[i] = arrItem;
    }

    long result = candies(n, arr);

    Console.WriteLine(result);
  }
}
