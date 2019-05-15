using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{

    private static string[] Grid;
    private static bool[,] Marked;
    private static int GridLength;
    private static readonly int[] movRows = new int[] { -1, -1, 0, 1, 1, 1, 0 };
    private static readonly int[] movCols = new int[] { 0, 1, 1, 1, 0, -1, -1, -1 };
    private const char BLOCKED_CELL = 'X';

    class Position
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public Position Parent { get; set; }

        public Position Clone()
        {
            return new Position()
            {
                Row = this.Row,
                Col = this.Col,
            };
        }

        public static bool operator ==(Position p1, Position p2)
        {
            return p1.Row == p2.Row && p1.Col == p2.Col;
        }

        public static bool operator !=(Position p1, Position p2)
        {
            return p1.Row != p2.Row || p1.Col != p2.Col;
        }
    }

    // Complete the minimumMoves function below.
    static int minimumMoves(int startX, int startY, int goalX, int goalY)
    {
        var queue = new Queue<Position>();
        queue.Enqueue(new Position() { Row = startX, Col = startY });
        var target = new Position() { Row = goalX, Col = goalY };
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            Marked[current.Row, current.Col] = true;
            if (current == target)
                return OptimzeSteps(current);

            foreach (Position neighboor in GetNeighbors(current))
            {
                Marked[neighboor.Row, neighboor.Col] = true;
                queue.Enqueue(neighboor);
            }
        }

        return -1;
    }

    private static int OptimzeSteps(Position current)
    {
        int steps = 0;
        var startTurn = current;
        while (startTurn.Parent != null)
        {
            var endTurn = startTurn;
            while ((startTurn.Row == endTurn.Row && endTurn.Parent != null)
                || (startTurn.Col == endTurn.Col && endTurn.Parent != null))
                endTurn = endTurn.Parent;

            steps += 1;
            startTurn = endTurn;
        }
        return steps;
    }

    static int[] _rowDirection = new int[] { -1, -1, 0, 1, 1, 1, 0, -1 };
    static int[] _colDirection = new int[] { 0, 1, 1, 1, 0, -1, -1, -1 };

    private static IEnumerable<Position> GetNeighbors(Position pos)
    {
        foreach (var dir in Enumerable.Zip<int, int, Tuple<int, int>>(_rowDirection, _colDirection, (row, col) => Tuple.Create(row, col)))
        {
            var newPos = new Position()
            {
                Row = pos.Row + dir.Item1,
                Col = pos.Col + dir.Item2,
                Parent = pos
            };
            if (newPos.Row >= 0 && newPos.Col >= 0 && newPos.Row < GridLength && newPos.Col < GridLength && !Marked[newPos.Row, newPos.Col])
                yield return newPos;
        }
    }

    private static void MarkBlockedCells()
    {
        for (int i = 0; i < GridLength; i++)
        {
            for (int j = 0; j < GridLength; j++)
            {
                if (Grid[i][j] == BLOCKED_CELL)
                {
                    Marked[i, j] = true;
                }
            }
        }
    }

    static void Main(string[] args)
    {

        int n = Convert.ToInt32(Console.ReadLine());

        string[] grid = new string[n];

        for (int i = 0; i < n; i++)
        {
            string gridItem = Console.ReadLine();
            grid[i] = gridItem;
        }

        string[] startXStartY = Console.ReadLine().Split(' ');

        int startX = Convert.ToInt32(startXStartY[0]);

        int startY = Convert.ToInt32(startXStartY[1]);

        int goalX = Convert.ToInt32(startXStartY[2]);

        int goalY = Convert.ToInt32(startXStartY[3]);

        Grid = grid;
        GridLength = grid.Length;
        Marked = new bool[GridLength, GridLength];
        MarkBlockedCells();

        int result = minimumMoves(startX, startY, goalX, goalY);

        Console.WriteLine(result);
    }
}
