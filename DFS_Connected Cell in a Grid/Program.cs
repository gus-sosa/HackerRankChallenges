using System;
using System.Collections.Generic;
using System.Linq;

internal class Solution
{

    // Complete the maxRegion function below.
    private static int maxRegion(int n , int m , int[][] grid)
    {
        var marked = new bool[n , m];
        var max = 0;
        for (var i = 0 ; i < n ; i++)
            for (var j = 0 ; j < m ; j++)
                if (grid[i][j] == 1 && !marked[i , j])
                {
                    var countOnes = DFS(i , j , grid , marked);
                    max = Math.Max(max , countOnes);
                }

        return max;
    }

    private static int DFS(int i , int j , int[][] grid , bool[,] marked)
    {
        marked[i , j] = true;
        var count = 1;
        foreach (Tuple<int , int> adj in GetAdj(i , j , grid.Length , grid[0].Length , grid).Where((Tuple<int , int> a) => !marked[a.Item1 , a.Item2] && grid[a.Item1][a.Item2] == 1))
            count += DFS(adj.Item1 , adj.Item2 , grid , marked);
        return count;
    }

    private static readonly int[] movRows = new int[] { -1 , -1 , 0 , 1 , 1 , 1 , 0 , -1 };
    private static readonly int[] movCols = new int[] { 0 , 1 , 1 , 1 , 0 , -1 , -1 , -1 };

    private static IEnumerable<Tuple<int , int>> GetAdj(int i , int j , int n , int m , int[][] grid)
    {
        foreach (Tuple<int , int> item in Enumerable.Zip(movRows , movCols , (r , c) => Tuple.Create(r , c)))
        {
            var newRow = i + item.Item1;
            var newCol = j + item.Item2;
            if (newRow >= 0 && newCol >= 0 && newRow < n && newCol < m)
                yield return Tuple.Create(newRow , newCol);
        }
    }

    private static void Main(string[] args)
    {
        var n = Convert.ToInt32(Console.ReadLine());

        var m = Convert.ToInt32(Console.ReadLine());

        var grid = new int[n][];

        for (var i = 0 ; i < n ; i++)
        {
            grid[i] = Array.ConvertAll(Console.ReadLine().Split(' ') , gridTemp => Convert.ToInt32(gridTemp));
        }

        var res = maxRegion(n , m , grid);

        Console.WriteLine(res);
    }
}
