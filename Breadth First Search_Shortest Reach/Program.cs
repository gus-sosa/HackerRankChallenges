using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadth_First_Search_Shortest_Reach
{
    class Program
    {
        const int MAX_NODES = 1000;
        static int[] dsts = new int[MAX_NODES + 1];

        static void PrintDsts(int s, bool[,] matrix, int n, int m)
        {
            for (int i = 1; i <= n; i++)
                dsts[i] = -1;
            dsts[s] = 0;

            var queue = new Queue<int>();
            queue.Enqueue(s);
            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                for (int i = 1; i <= n; i++)
                    if (dsts[i] == -1 && matrix[currentNode, i])
                    {
                        dsts[i] = dsts[currentNode] + 1;
                        queue.Enqueue(i);
                    }
            }

            for (int i = 1; i <= n; i++)
                if (i != s)
                    Console.Write(dsts[i] == -1 ? "-1 " : 6 * dsts[i] + " ");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int q = int.Parse(Console.ReadLine());
            int n, m, s;
            bool[,] matrix = new bool[MAX_NODES + 1, MAX_NODES + 1];
            while (q-- > 0)
            {
                string[] tokens = Console.ReadLine().Split();
                n = int.Parse(tokens[0]);
                m = int.Parse(tokens[1]);

                for (int i = 0; i <= n; i++)
                    for (int j = 0; j <= n; j++)
                        matrix[i, j] = false;

                for (int i = 0; i < m; i++)
                {
                    tokens = Console.ReadLine().Split();
                    int v1 = int.Parse(tokens[0]);
                    int v2 = int.Parse(tokens[1]);
                    matrix[v1, v2] = matrix[v2, v1] = true;
                }

                s = int.Parse(Console.ReadLine());
                PrintDsts(s, matrix, n, m);
            }
        }
    }
}
