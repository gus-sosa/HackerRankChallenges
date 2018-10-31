using System;
using System.Collections.Generic;
using System.Linq;

internal class Solution
{
    private static long c_lib, c_road;
    private static List<int>[] graph;
    private static bool[] marked;
    // Complete the roadsAndLibraries function below.
    private static long roadsAndLibraries(int n , int c_lib , int c_road , int[][] cities)
    {
        //Debugger.Launch();
        Solution.c_lib = c_lib;
        Solution.c_road = c_road;
        marked = new bool[n];
        graph = BuildGraph(cities , n);

        long cost = 0;
        for (var i = 0 ; i < n ; i++)
            if (!marked[i])
                cost += dfs(i , c_lib);

        return cost;
    }

    private static long dfs(int i , long currentCost)
    {
        marked[i] = true;
        long minCost = 0;
        foreach (var adj in adjacents(i , graph).Where(a => !marked[a]))
            minCost += dfs(adj , Math.Min(currentCost + c_lib , currentCost + c_road));
        return minCost == 0 ? currentCost : minCost;
    }

    private static IEnumerable<int> adjacents(int i , List<int>[] graph)
    {
        foreach (var item in graph[i])
            yield return item;
    }

    private static List<int>[] BuildGraph(int[][] cities , int n)
    {
        var graph = new List<int>[n];

        for (var i = 0 ; i < n ; i++)
            graph[i] = new List<int>();

        for (var i = 0 ; i < cities.Length ; i++)
        {
            int a = cities[i][0] - 1, b = cities[i][1] - 1;
            graph[a].Add(b);
            graph[b].Add(a);
        }

        return graph;
    }

    private static void Main(string[] args)
    {
        var q = Convert.ToInt32(Console.ReadLine());

        for (var qItr = 0 ; qItr < q ; qItr++)
        {
            var nmC_libC_road = Console.ReadLine().Split(' ');

            var n = Convert.ToInt32(nmC_libC_road[0]);

            var m = Convert.ToInt32(nmC_libC_road[1]);

            var c_lib = Convert.ToInt32(nmC_libC_road[2]);

            var c_road = Convert.ToInt32(nmC_libC_road[3]);

            var cities = new int[m][];

            for (var i = 0 ; i < m ; i++)
            {
                cities[i] = Array.ConvertAll(Console.ReadLine().Split(' ') , citiesTemp => Convert.ToInt32(citiesTemp));
            }

            var result = roadsAndLibraries(n , c_lib , c_road , cities);

            Console.WriteLine(result);
        }
    }
}
