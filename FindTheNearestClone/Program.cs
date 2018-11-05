using System;
using System.Collections.Generic;

internal class Solution
{

    // Complete the findShortest function below.

    /*
     * For the unweighted graph, <name>:
     *
     * 1. The number of nodes is <name>Nodes.
     * 2. The number of edges is <name>Edges.
     * 3. An edge exists between <name>From[i] to <name>To[i].
     *
     */
    private static int findShortest(int graphNodes , int[] graphFrom , int[] graphTo , long[] ids , int val)
    {
        List<int>[] graph = BuildGraph(graphNodes , graphFrom , graphTo);
        var shortest = int.MaxValue;

        for (var i = 0 ; i < ids.Length ; i++)
            if (ids[i] == val)
            {
                var costs = bfs(i , graph);
                for (var j = 0 ; j < ids.Length ; j++)
                    if (i != j && ids[j] == val)
                        shortest = Math.Min(costs[j] , shortest);
            }

        return shortest == int.MaxValue ? -1 : shortest;
    }

    private static int[] bfs(int i , List<int>[] graph)
    {
        var costs = new int[graph.Length];
        var marked = new bool[graph.Length];
        marked[i] = true;
        var queue = new Queue<Tuple<int , int>>();
        queue.Enqueue(Tuple.Create(i , 0));
        while (queue.Count > 0)
        {
            Tuple<int , int> current = queue.Dequeue();
            var currentNode = current.Item1;
            var currentCost = current.Item2;

            foreach (var adj in graph[currentNode])
                if (!marked[adj])
                {
                    marked[adj] = true;
                    costs[adj] = currentCost + 1;
                    queue.Enqueue(Tuple.Create(adj , costs[adj]));
                }
        }
        return costs;
    }

    private static List<int>[] BuildGraph(int graphNodes , int[] graphFrom , int[] graphTo)
    {
        var graph = new List<int>[graphNodes];
        for (var i = 0 ; i < graphNodes ; i++)
            graph[i] = new List<int>();

        for (var i = 0 ; i < graphFrom.Length ; i++)
        {
            int a = graphFrom[i], b = graphTo[i];
            graph[a].Add(b);
            graph[b].Add(a);
        }
        return graph;
    }

    private static void Main(string[] args)
    {
        var graphNodesEdges = Console.ReadLine().Split(' ');
        var graphNodes = Convert.ToInt32(graphNodesEdges[0]);
        var graphEdges = Convert.ToInt32(graphNodesEdges[1]);

        var graphFrom = new int[graphEdges];
        var graphTo = new int[graphEdges];

        for (var i = 0 ; i < graphEdges ; i++)
        {
            var graphFromTo = Console.ReadLine().Split(' ');
            graphFrom[i] = Convert.ToInt32(graphFromTo[0]) - 1;
            graphTo[i] = Convert.ToInt32(graphFromTo[1]) - 1;
        }

        var ids = Array.ConvertAll(Console.ReadLine().TrimEnd().TrimStart().Split(' ') , idsTemp => Convert.ToInt64(idsTemp))
        ;
        var val = Convert.ToInt32(Console.ReadLine());

        var ans = findShortest(graphNodes , graphFrom , graphTo , ids , val);

        Console.WriteLine(ans);
    }
}
