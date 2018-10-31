using System;
using System.Collections.Generic;
using System.Linq;

internal class Solution
{

    // Complete the roadsAndLibraries function below.
    private static long roadsAndLibraries(int n , int c_lib , int c_road , int[][] cities)
    {
        int numComponents = 0, numRoadsToBuild = 0;
        var marked = new bool[n];
        List<int>[] graph = BuildGraph(cities , n);
        for (var i = 0 ; i < n ; i++)
            if (!marked[i])
            {
                numComponents++;
                numRoadsToBuild += dfs(i , graph , marked);
            }

        return numComponents * (c_lib - c_road) + c_road * numRoadsToBuild;
    }

    private static int dfs(int i , List<int>[] graph , bool[] marked)
    {
        var numMarked = 0;
        marked[i] = true;
        foreach (var adj in adjacents(i , graph).Where(a => !marked[a]))
            numMarked += dfs(adj , graph , marked) + 1;
        return numMarked;
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
            int a = cities[i][0], b = cities[i][1];
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
