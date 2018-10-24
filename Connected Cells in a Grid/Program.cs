using System;
using System.Collections.Generic;
using System.Diagnostics;

internal class Solution
{

    // Complete the connectedCell function below.
    private static int connectedCell(int[][] matrix)
    {
        int numRows = matrix.Length,
            numCols = matrix[0].Length;
        var marked = new bool[numRows , numCols];
        var maxNum = 0;
        var queue = new Queue<Tuple<int , int>>();

        for (var i = 0 ; i < numRows ; i++)
            for (var j = 0 ; j < numCols ; j++)
                if (matrix[i][j] == 1 && !marked[i , j])
                {
                    queue.Enqueue(Tuple.Create(i , j));
                    maxNum = Math.Max(maxNum , GetNumAdjacentCells(matrix , marked , numRows , numCols , queue));
                }


        return maxNum;
    }

    private static int GetNumAdjacentCells(int[][] matrix , bool[,] marked , int numRows , int numCols , Queue<Tuple<int , int>> queue)
    {
        Tuple<int , int> currentCell = queue.Dequeue();
        var num = 1;
        marked[currentCell.Item1 , currentCell.Item2] = true;
        while (currentCell != null)
        {
            foreach (Tuple<int , int> adjacent in GetAdjacentCells(currentCell.Item1 , currentCell.Item2 , numRows , numCols))
                if (matrix[adjacent.Item1][adjacent.Item2] == 1 && !marked[adjacent.Item1 , adjacent.Item2])
                {
                    queue.Enqueue(adjacent);
                    marked[adjacent.Item1 , adjacent.Item2] = true;
                    num++;
                }

            currentCell = null;
            if (queue.Count > 0)
                currentCell = queue.Dequeue();
        }
        return num;
    }

    private static readonly int[] rowMovs = new[] { -1 , -1 , 0 , 1 , 1 , 1 , 0 };
    private static readonly int[] colMovs = new[] { 0 , -1 , -1 , -1 , 0 , 1 , 1 , 1 };

    private static IEnumerable<Tuple<int , int>> GetAdjacentCells(int row , int col , int numRows , int numCols)
    {
        int newRow, newCol;
        for (var i = 0 ; i < rowMovs.Length ; i++)
        {
            newRow = row + rowMovs[i];
            newCol = col + colMovs[i];
            if (newRow >= 0 && newCol >= 0 && newRow < numRows && newCol < numCols)
                yield return Tuple.Create(newRow , newCol);
        }
    }

    private static void Main(string[] args)
    {
        //Debugger.Launch();

        var n = Convert.ToInt32(Console.ReadLine());

        var m = Convert.ToInt32(Console.ReadLine());

        var matrix = new int[n][];

        for (var i = 0 ; i < n ; i++)
        {
            matrix[i] = Array.ConvertAll(Console.ReadLine().Split(' ') , matrixTemp => Convert.ToInt32(matrixTemp));
        }

        var result = connectedCell(matrix);

        Console.WriteLine(result);
    }
}
