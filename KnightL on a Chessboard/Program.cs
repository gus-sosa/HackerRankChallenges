using System;
using System.Collections.Generic;
class Solution {
    class Pos {
        public int Row { get; set; }
        public int Col { get; set; }
    }
    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        Queue<Pos> queue = new Queue<Pos>();
        var initialPos = new Pos();
        int[,] matrix = new int[n, n];
        for (int i = 0; i < n - 1; i++) {
            for (int j = 0; j < n - 1; j++) {
                CleanMatrix(matrix, n);
                matrix[0, 0] = 0;
                queue.Clear();
                queue.Enqueue(initialPos);
                Console.Write(MinSteps(matrix, queue, i + 1, j + 1, n));
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
    private static int MinSteps(int[,] matrix, Queue<Pos> queue, int a, int b, int n) {
        while (queue.Count > 0) {
            var currentValue = queue.Dequeue();
            var countNextSteps = matrix[currentValue.Row, currentValue.Col] + 1;
            foreach (Pos nextStep in GetNextSteps(currentValue.Row, currentValue.Col, a, b, n)) {
                if (nextStep.Row == n - 1 && nextStep.Col == n - 1) {
                    return countNextSteps;
                }
                if (matrix[nextStep.Row, nextStep.Col] >= countNextSteps) {
                    matrix[nextStep.Row, nextStep.Col] = countNextSteps;
                    queue.Enqueue(nextStep);
                }
            }
        }

        return -1;
    }
    private static IEnumerable<Pos> GetNextSteps(int row, int col, int a, int b, int n) {
        int[] a_values = new int[] { a, -a, a, -a };
        int[] b_values = new int[] { b, b, -b, -b };
        for (int i = 0; i < 4; i++) {
            if (row + a_values[i] >= 0 && row + a_values[i] < n && col + b_values[i] >= 0 && col + b_values[i] < n) {
                yield return new Pos { Row = row + a_values[i], Col = col + b_values[i] };
            }
            if (row + b_values[i] >= 0 && row + b_values[i] < n && col + a_values[i] >= 0 && col + a_values[i] < n) {
                yield return new Pos { Row = row + b_values[i], Col = col + a_values[i] };
            }
        }
    }
    private static void CleanMatrix(int[,] matrix, int n) {
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                matrix[i, j] = int.MaxValue;
            }
        }
    }
}