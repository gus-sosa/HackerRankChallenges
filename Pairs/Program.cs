using System;
using System.Collections.Generic;
class Solution
{
    /* Head ends here */
    static int pairs(int[] a, ulong k)
    {
        var set = new HashSet<ulong>();
        int count = 0;

        foreach (ulong item in a)
            set.Add(k + item);

        foreach (ulong item in a)
            count += set.Contains(item) ? 1 : 0;

        return count;
    }
    /* Tail starts here */
    static void Main(String[] args)
    {
        int res;

        String line = Console.ReadLine();
        String[] line_split = line.Split(' ');
        int _a_size = Convert.ToInt32(line_split[0]);
        int _k = Convert.ToInt32(line_split[1]);
        int[] _a = new int[_a_size];
        int _a_item;
        String move = Console.ReadLine();
        String[] move_split = move.Split(' ');
        for (int _a_i = 0; _a_i < move_split.Length; _a_i++)
        {
            _a_item = Convert.ToInt32(move_split[_a_i]);
            _a[_a_i] = _a_item;
        }

        res = pairs(_a, (ulong)_k);
        Console.WriteLine(res);

    }
}
