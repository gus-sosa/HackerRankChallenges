using System;
using System.Collections.Generic;
class Solution {
    static void Main(String[] args) {
        string[] tokens_m = Console.ReadLine().Split(' ');
        int m = Convert.ToInt32(tokens_m[0]);
        int n = Convert.ToInt32(tokens_m[1]);
        string[] magazine = Console.ReadLine().Split(' ');
        string[] ransom = Console.ReadLine().Split(' ');
        Dictionary<string, int> hash = new Dictionary<string, int>();
        foreach (var item in magazine) {
            if (hash.ContainsKey(item)) {
                hash[item]++;
            } else {
                hash[item] = 1;
            }
        }
        bool flag = true;
        foreach (var item in ransom) {
            if (!hash.ContainsKey(item)) {
                flag = false;
                break;
            } else {
                hash[item]--;
                if (hash[item] == 0) {
                    hash.Remove(item);
                }
            }
        }
        Console.WriteLine(flag ? "Yes" : "No");
    }
}