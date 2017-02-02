using System;
public class Solution {
    public static void Main(string[] args) {
        long a = 0, b = 0, x = 0, y = 0;
        int n = int.Parse(Console.ReadLine());
        string[] arr = new string[4];
        while (n-- != 0) {
            arr = Console.ReadLine().Split(' ');
            a = long.Parse(arr[0]);
            b = long.Parse(arr[1]);
            x = long.Parse(arr[2]);
            y = long.Parse(arr[3]);

            Console.WriteLine(Math.Abs(x - a) % b == 0 && (b == y || Math.Abs(y - a) % b == 0) ? "YES" : "NO");
        }
    }
}