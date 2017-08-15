using System;
class Solution
{
    static void Main(String[] args)
    {
        Console.ReadLine();//skipping n
        string B = Console.ReadLine();
        Console.WriteLine((B.Length - B.Replace("010", "").Length) / 3);
    }
}