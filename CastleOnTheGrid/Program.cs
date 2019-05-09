using System;
using System.Collections.Generic;

class Solution
{

    private static string[] Grid;
    private static bool[,] Marked;
    private static int GridLength;
    private static readonly int[] movRows = new int[] { -1, -1, 0, 1, 1, 1, 0 };
    private static readonly int[] movCols = new int[] { 0, 1, 1, 1, 0, -1, -1, -1 };
    private const char BLOCKED_CELL = 'X';

    struct Position
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Steps { get; set; }

        public Position Clone()
        {
            return new Position()
            {
                Row = this.Row,
                Col = this.Col,
                Steps = this.Steps
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
        var endPoint = new Position() { Row = goalX, Col = goalY };
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            Marked[current.Row, current.Col] = true;
            if (current == endPoint)
            {
                return current.Steps;
            }

            AddNeighbors(queue, current);
        }
        return -1;
    }



    private static void AddNeighbors(Queue<Position> queue, Position current)
    {
        foreach (Position newPos in GetEmptyNeighbors(current))
        {
            Marked[newPos.Row, newPos.Col] = true;
            queue.Enqueue(newPos);
        }
    }

    private static IEnumerable<Position> GetEmptyNeighbors(Position current)
    {
        foreach (Position pos in GetEmptyNeighborsByDirection(current, true))
            yield return pos;

        foreach (Position pos in GetEmptyNeighborsByDirection(current, false))
            yield return pos;
    }

    private static IEnumerable<Position> GetEmptyNeighborsByDirection(Position position, bool rowDirection)
    {
        var pivot = position.Clone();
        ++pivot.Steps;
        bool flag = true;
        while (flag)
        {
            if (rowDirection) ++pivot.Col;
            else ++pivot.Row;
            if (GoodCell(pivot))
            {
                yield return pivot;
                pivot = pivot.Clone();
            }
            else
                flag = false;
        }
        pivot = position.Clone();
        ++pivot.Steps;
        flag = true;
        while (flag)
        {
            if (rowDirection) --pivot.Col;
            else --pivot.Row;
            if (GoodCell(pivot))
            {
                yield return pivot;
                pivot = pivot.Clone();
            }
            else
                flag = false;
        }
    }

    private static bool GoodCell(Position position)
    {
        return position.Row >= 0 && position.Col >= 0 && position.Col < GridLength && position.Row < GridLength && !Marked[position.Row, position.Col];
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
