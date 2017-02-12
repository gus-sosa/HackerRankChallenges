using System;
class Solution {
    static void Main(String[] args) {
        int q = Convert.ToInt32(Console.ReadLine());
        int indexWord = 0;
        string word = "hackerrank";
        while (q-- > 0) {
            string s = Console.ReadLine();
            indexWord = 0;
            for (int i = 0; i < s.Length && indexWord < word.Length; i++) {
                if (word[indexWord] == s[i]) {
                    indexWord++;
                }
            }
            Console.WriteLine(indexWord == word.Length ? "YES" : "NO");
        }
    }
}