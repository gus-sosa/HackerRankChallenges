using System;
public class Solution {
    public static long gcd(long a, long b) {
        return b == 0 ? a : gcd(b, a % b);
    }

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

            Console.WriteLine(gcd(a, b) == gcd(x, y) ? "YES" : "NO");
        }
    }
}