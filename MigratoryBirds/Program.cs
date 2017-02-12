using System;
class Solution {

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] types = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
        int ids_size = 5;
        int[] ids = new int[ids_size + 1];
        foreach (var i in types) {
            ids[i]++;
        }
        int higestIndex = 1;
        for (int i = higestIndex + 1; i < ids_size + 1; i++) {
            if (ids[i] > ids[higestIndex]) {
                higestIndex = i;
            }
        }
        Console.WriteLine(higestIndex);
    }
}