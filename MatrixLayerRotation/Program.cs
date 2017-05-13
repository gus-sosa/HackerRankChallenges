using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLayerRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int m, n, r;
            string[] tokens = Console.ReadLine().Split();
            m = Convert.ToInt32(tokens[0]);
            n = Convert.ToInt32(tokens[1]);
            r = Convert.ToInt32(tokens[2]);
            int[,] matrix = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                tokens = Console.ReadLine().Split();
                for (int j = 0; j < n; j++)
                    matrix[i, j] = Convert.ToInt32(tokens[j]);
            }

            Print(GetMatrixRotated(matrix, r));
        }

        private static int[,] GetMatrixRotated(int[,] matrix, int r)
        {
            int m = matrix.GetLength(0), n = matrix.GetLength(1);
            int[,] result = new int[m, n];

            for (int numLayers = Math.Min(m, n) / 2, numLayerSkiped = 0; numLayerSkiped < numLayers; numLayerSkiped++)
                RotateLayer(numLayerSkiped, matrix, r, result);

            return result;
        }

        private static void RotateLayer(int numLayerSkiped, int[,] matrix, int r, int[,] result)
        {
            int m = matrix.GetLength(0), n = matrix.GetLength(1);
            int width = n - 2 * numLayerSkiped, height = m - 2 * numLayerSkiped;
            int totalPositions = 2 * (width + height) - 4;
            int rot = r % totalPositions;
            int row, col;

            //rotating first row
            row = height - 1;
            col = width - 1;
            for (int i = 0; i < width; i++, col++)
            {
                int currentValue = matrix[row, col];
                int x, y;
                GetCoords(width, height, row, col, rot, out x, out y);
                result[x + height - 1, y + width - 1] = currentValue;
            }

            //rotating last row
            row = m - height - 1;
            col = width - 1;
            for (int i = 0; i < width; i++, col++)
            {
                int currentValue = matrix[row, col];
                int x, y;
                GetCoords(width, height, row, col, rot, out x, out y);
                result[x + height - 1, y + width - 1] = currentValue;
            }

            //rotating first column
            row = height - 1;
            col = width - 1;
            for (int i = 0; i < height; i++, row++)
            {
                int currentValue = matrix[row, col];
                int x, y;
                GetCoords(width, height, row, col, rot, out x, out y);
                result[x + height - 1, y + width - 1] = currentValue;
            }

            //rotation last column
            row = height - 1;
            col = n - width - 1;
            for (int i = 0; i < height; i++, row++)
            {
                int currentValue = matrix[row, col];
                int x, y;
                GetCoords(width, height, row, col, rot, out x, out y);
                result[x + height - 1, y + width - 1] = currentValue;
            }
        }

        private static void GetCoords(int width, int height, int row, int col, int rot, out int x, out int y)
        {
            throw new NotImplementedException();
        }

        private static void Print(int[,] matrix)
        {
            int m = matrix.GetLength(0), n = matrix.GetLength(1);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
        }
    }
}
