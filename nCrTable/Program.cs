using System;
using System.Text;

namespace nCrTable
{
    class Program
    {
        static readonly int MAX_LENGTH = 1001;
        private static readonly int module = 1000000000;
        static int[,] table = new int[MAX_LENGTH, MAX_LENGTH];
        static void Main(string[] args)
        {
            PreCompute();
            int t = int.Parse(Console.ReadLine());
            var stringBuilder = new StringBuilder();
            while (t-- > 0)
            {
                int n = int.Parse(Console.ReadLine());
                stringBuilder.Clear();
                for (int i = 0; i <= n; i++)
                    stringBuilder.AppendFormat("{0} ", table[n, i]);
                Console.WriteLine(stringBuilder);
            }
        }

        private static void PreCompute()
        {
            for (int row = 0; row < MAX_LENGTH; row++)
            {
                table[row, 0] = table[row, row] = 1;
                for (int col = 1; col < row; col++)
                    table[row, col] = (table[row - 1, col] + table[row - 1, col - 1]) % module;
            }
        }
    }
}