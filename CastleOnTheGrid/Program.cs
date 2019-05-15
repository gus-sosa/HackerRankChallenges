using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{

  private static string[] Grid;
  private static bool[,] Marked;
  private static int[,] BestSteps;
  private static int[,] BestTurns;
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
    public int Turns { get; set; }

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

  static Position target;
  static int bestNumSteps = int.MaxValue;
  static int bestNumTurns = int.MaxValue;

  // Complete the minimumMoves function below.
  static int minimumMoves(int startX, int startY, int goalX, int goalY) {
    target = new Position() { Row = goalX, Col = goalY };
    minimumMoves(new Position() { Row = startX, Col = startY });
    return bestNumTurns;
  }

  private static void minimumMoves(Position position) {
    if (position.Steps <= bestNumSteps && position.Turns <= bestNumTurns
      && position.Steps <= BestSteps[position.Row, position.Col]
      && position.Turns <= BestTurns[position.Row, position.Col]) {
      BestSteps[position.Row, position.Col] = Math.Min(position.Steps, BestSteps[position.Row, position.Col]);
      BestTurns[position.Row, position.Col] = Math.Min(position.Turns, BestTurns[position.Row, position.Col]);
      if (Position.Equals(position, target)) {
        bestNumSteps = Math.Min(position.Steps, bestNumSteps);
        bestNumTurns = Math.Min(bestNumTurns, position.Turns);
      } else {
        Marked[position.Row, position.Col] = true;
        foreach (var neighboor in GetNeighbors(position)) {
          minimumMoves(neighboor);
        }
        Marked[position.Row, position.Col] = false;
      }
    }
  }

  private static void UpdatePath(Position position) {
    while (position != null) {
      BestTurns[position.Row, position.Col] = Math.Min(position.Turns, BestTurns[position.Row, position.Col]);
      BestSteps[position.Row, position.Col] = Math.Min(position.Steps, BestSteps[position.Row, position.Col]);
      position = position.Parent;
    }
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
      newPos.Turns = pos.Parent == null ? 1 : (Position.Equals(pos, new Position() { Row = pos.Parent.Row + dir.Item1, Col = pos.Parent.Col + dir.Item2 }) ? pos.Turns : pos.Turns + 1);
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
    BestSteps = new int[GridLength, GridLength];
    BestTurns = new int[GridLength, GridLength];
    for (int i = 0; i < GridLength; i++) {
      for (int j = 0; j < GridLength; j++) {
        BestSteps[i, j] = BestTurns[i, j] = int.MaxValue;
      }
    }
    MarkBlockedCells();

    int result = minimumMoves(startX, startY, goalX, goalY);

    Console.WriteLine(result);
  }
}
