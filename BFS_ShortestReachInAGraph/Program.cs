using System;
using System.Collections.Generic;
using System.Linq;

internal class Solution
{
    private static void Main(string[] args)
    {
        var q = int.Parse(Console.ReadLine());
        while (q-- > 0)
        {
            var tokens = Console.ReadLine().Split();
            var n = int.Parse(tokens[0]);
            var m = int.Parse(tokens[1]);
            List<int>[] graph = BuildGraph(n , m);
            var s = int.Parse(Console.ReadLine()) - 1;
            var bestDsts = ComputesBestDistances(graph , s , n);
            foreach (var item in bestDsts.Take(bestDsts.Length - 1))
                Console.Write($"{item} ");
            Console.WriteLine(bestDsts[bestDsts.Length - 1]);
        }
    }

    private static int[] ComputesBestDistances(List<int>[] graph , int s , int n)
    {
        var costs = Enumerable.Repeat(-1 , n).ToArray();
        var marked = new bool[n];
        var queue = new Queue<int>();
        queue.Enqueue(s);
        costs[s] = 0;
        marked[s] = true;
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            foreach (var adj in graph[current].Where(a => !marked[a]))
            {
                marked[adj] = true;
                costs[adj] = 1 + costs[current];
                queue.Enqueue(adj);
            }
        }
        return costs.Select(i => i == -1 ? i : i * 6).Where((_ , index) => index != s).ToArray();
    }

    private static List<int>[] BuildGraph(int n , int m)
    {
        var graph = new List<int>[n];
        for (var i = 0 ; i < n ; i++)
            graph[i] = new List<int>();
        for (var i = 0 ; i < m ; i++)
        {
            var tokens = Console.ReadLine().Split();
            var a = int.Parse(tokens[0]) - 1;
            var b = int.Parse(tokens[1]) - 1;
            graph[a].Add(b);
            graph[b].Add(a);
        }
        return graph;
    }
}