using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

  class HeightInfo
  {
    public HeightInfo(int height, int pos)
    {
      Height = height;
      Pos = pos;
    }

    public int Height { get; set; }
    public int Pos { get; set; }
  }

  // Complete the largestRectangle function below.
  static long largestRectangle(int[] h)
  {
    var stack = new Stack<HeightInfo>();
    long max = 0;
    for (int i = 0; i < h.Length; i++)
    {
      int currentHeight = h[i];
      int currentPos = i;
      while (stack.Count > 0 && stack.Peek().Height > currentHeight)
      {
        currentPos = stack.Peek().Pos;
        max = GetMaxHeight(stack, max, i);
      }
      stack.Push(new HeightInfo(currentHeight, currentPos));
    }

    while (stack.Count > 0)
      max = GetMaxHeight(stack, max, h.Length);

    return max;
  }

  static long GetMaxHeight(Stack<HeightInfo> stack, long max, int pos)
  {
    HeightInfo heightInfoTop = stack.Pop();
    return Math.Max(max, heightInfoTop.Height * (pos - heightInfoTop.Pos));
  }

  static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    int n = Convert.ToInt32(Console.ReadLine());

    int[] h = Array.ConvertAll(Console.ReadLine().Split(' '), hTemp => Convert.ToInt32(hTemp))
    ;
    long result = largestRectangle(h);

    textWriter.WriteLine(result);

    textWriter.Flush();
    textWriter.Close();
  }
}
