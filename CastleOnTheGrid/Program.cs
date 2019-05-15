using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{

  private static string[] Grid;
  private static bool[,] Marked;
  private static int GridLength;
  const int NUM_DIR = 4;
  private static readonly int[] movRows = new int[] { -1, 0, 1, 0 };
  private static readonly int[] movCols = new int[] { 0, 1, 0, -1 };
  private const char BLOCKED_CELL = 'X';

  class Position
  {
    public int Row { get; set; }
    public int Col { get; set; }
    public Position Parent { get; set; }
    public int Steps { get; set; }

    public Position Clone() {
      return new Position()
      {
        Row = this.Row,
        Col = this.Col,
      };
    }

    public override bool Equals(object obj) {
      Position pos = obj as Position;
      if (pos == null) {
        return false;
      }
      return pos.Row == Row && pos.Col == Col;
    }
  }

  // Complete the minimumMoves function below.
  static int minimumMoves(int startX, int startY, int goalX, int goalY) {
    var queue = new Queue<Position>();
    queue.Enqueue(new Position() { Row = startX, Col = startY });
    Marked[startX, startY] = true;
    var target = new Position() { Row = goalX, Col = goalY };
    int bestPathDist = int.MaxValue;
    int numBestSteps = int.MaxValue;
    while (queue.Count > 0) {
      var current = queue.Dequeue();
      if (current.Steps > bestPathDist) {
        continue;
      }
      if (Position.Equals(current, target)) {
        bestPathDist = OptimzeSteps(current);
        numBestSteps = current.Steps;
        continue;
      }
      foreach (Position neighboor in GetNeighbors(current)) {
        Marked[neighboor.Row, neighboor.Col] = true;
        queue.Enqueue(neighboor);
      }
    }
    return -1;
  }

  private static int OptimzeSteps(Position current) {
    int steps = 0;
    var startTurn = current;
    while (startTurn.Parent != null) {
      int dir = ChooseDirection(startTurn);
      startTurn = GetEndTurn(startTurn, dir);
      steps += 1;
    }
    return steps;
  }

  private static Position GetEndTurn(Position startTurn, int dir) {
    var flag = true;
    var endTurn = startTurn;
    Position pivot;
    while (flag) {
      pivot = new Position() { Row = endTurn.Row + movRows[dir], Col = endTurn.Col + movCols[dir] };
      flag = Position.Equals(endTurn.Parent, pivot);
      if (flag) {
        endTurn = endTurn.Parent;
      }
    }
    return endTurn;
  }

  private static int ChooseDirection(Position startTurn) {
    int dir = 0;
    for (Position pivot; dir < NUM_DIR; dir++) {
      pivot = new Position() { Row = startTurn.Row + movRows[dir], Col = startTurn.Col + movCols[dir] };
      if (Position.Equals(pivot, startTurn.Parent)) {
        break;
      }
    }
    return dir;
  }



  private static IEnumerable<Position> GetNeighbors(Position pos) {
    foreach (var dir in Enumerable.Zip<int, int, Tuple<int, int>>(movRows, movCols, (row, col) => Tuple.Create(row, col))) {
      var newPos = new Position()
      {
        Row = pos.Row + dir.Item1,
        Col = pos.Col + dir.Item2,
        Steps = pos.Steps + 1,
        Parent = pos
      };
      if (newPos.Row >= 0 && newPos.Col >= 0 && newPos.Row < GridLength && newPos.Col < GridLength && !Marked[newPos.Row, newPos.Col])
        yield return newPos;
    }
  }

  private static void MarkBlockedCells() {
    for (int i = 0; i < GridLength; i++) {
      for (int j = 0; j < GridLength; j++) {
        if (Grid[i][j] == BLOCKED_CELL) {
          Marked[i, j] = true;
        }
      }
    }
  }

  static void Main(string[] args) {
    int n = Convert.ToInt32(Console.ReadLine());

    string[] grid = new string[n];

    for (int i = 0; i < n; i++) {
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
