using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLayerRotation
{
    class Program
    {
        static int[,] Mirror(int[,] m)
        {
            int[,] result = new int[m.GetLength(0), m.GetLength(1)];
            for (int i = 0; i < m.GetLength(0); i++)
                for (int j = 0; j < m.GetLength(1); j++)
                    result[m.GetLength(0) - i - 1, m.GetLength(1) - j - 1] = m[i, j];
            return result;
        }

        static int[,] RightRotation(int[,] m)
        {
            int[,] result = new int[m.GetLength(1), m.GetLength(0)];
            for (int i = 0; i < m.GetLength(0); i++)
                for (int j = 0; j < m.GetLength(1); j++)
                    result[j, m.GetLength(1) - i - 1] = m[i, j];
            return result;
        }

        static int[,] LeftRotation(int[,] m)
        {
            int[,] result = new int[m.GetLength(1), m.GetLength(0)];
            for (int i = 0; i < m.GetLength(0); i++)
                for (int j = 0; j < m.GetLength(1); j++)
                    result[m.GetLength(1) - j - 1, i] = m[i, j];
            return result;
        }

        static int[,] NoRotation(int[,] m)
        {
            return m;
        }

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

            Func<int[,], int[,]> RotationFunc;
            switch (r % 4)
            {
                case 1:
                    RotationFunc = RightRotation;
                    break;

                case 2:
                    RotationFunc = Mirror;
                    break;

                case 3:
                    RotationFunc = LeftRotation;
                    break;

                case 0:
                default:
                    RotationFunc = NoRotation;
                    break;
            }

            int[,] result = RotationFunc(matrix);
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                    Console.Write(result[i, j] + " ");
                Console.WriteLine();
            }
        }
    }
}
