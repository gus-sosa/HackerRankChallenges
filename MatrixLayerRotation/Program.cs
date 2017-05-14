using System;

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
            row = numLayerSkiped;
            col = numLayerSkiped;
            for (int i = 0; i < width; i++, col++)
            {
                int currentValue = matrix[row, col];
                int x, y;
                GetCoords(width, height, 0, i, rot, out x, out y);
                result[x + numLayerSkiped, y + numLayerSkiped] = currentValue;
            }

            //rotating last row
            row = m - numLayerSkiped - 1;
            col = numLayerSkiped;
            for (int i = 0; i < width; i++, col++)
            {
                int currentValue = matrix[row, col];
                int x, y;
                GetCoords(width, height, height - 1, i, rot, out x, out y);
                result[x + numLayerSkiped, y + numLayerSkiped] = currentValue;
            }

            //rotating first column
            row = numLayerSkiped;
            col = numLayerSkiped;
            for (int i = 0; i < height; i++, row++)
            {
                int currentValue = matrix[row, col];
                int x, y;
                GetCoords(width, height, i, 0, rot, out x, out y);
                result[x + numLayerSkiped, y + numLayerSkiped] = currentValue;
            }

            //rotation last column
            row = numLayerSkiped;
            col = n - numLayerSkiped - 1;
            for (int i = 0; i < height; i++, row++)
            {
                int currentValue = matrix[row, col];
                int x, y;
                GetCoords(width, height, i, width - 1, rot, out x, out y);
                result[x + numLayerSkiped, y + numLayerSkiped] = currentValue;
            }
        }

        private static void GetCoords(int width, int height, int row, int col, int rot, out int x, out int y)
        {
            x = row;
            y = col;

            while (rot > 0)
            {
                if (x == 0)//first row
                    if (y >= rot)
                    {
                        y -= rot;
                        rot = 0;
                    }
                    else
                    {
                        rot -= y;
                        y = 0;
                    }

                if (y == 0)//first column
                    if (height - x - 1 >= rot)
                    {
                        x += rot;
                        rot = 0;
                    }
                    else
                    {
                        rot -= height - x - 1;
                        x = height - 1;
                    }

                if (x == height - 1)//last row
                    if (width - y - 1 >= rot)
                    {
                        y += rot;
                        rot = 0;
                    }
                    else
                    {
                        rot -= width - y - 1;
                        y = width - 1;
                    }

                if (y == width - 1)//last column
                    if (x >= rot)
                    {
                        x -= rot;
                        rot = 0;
                    }
                    else
                    {
                        rot -= x;
                        x = 0;
                    }
            }
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