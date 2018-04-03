using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coinage
{
    class Program
    {
        static int[] denominations = { 1, 2, 5, 10 };
        static Dictionary<int[], ulong> map = new Dictionary<int[], ulong>();
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                int n = int.Parse(Console.ReadLine());
                int[] denominationsCount = Console.ReadLine().Split().Select(int.Parse).ToArray();
                Console.WriteLine(GetCombinations(n, denominationsCount.Length - 1, denominationsCount));
            }
        }

        private static ulong GetCombinations(int n, int currentPos, int[] denominationsCount)
        {
            if (n == 0)
                return 1;

            if (currentPos < 0)
                return 0;

            int[] newMap = new[] { n }.Concat(denominationsCount).ToArray();
            if (map.ContainsKey(newMap))
                return map[newMap];

            ulong result = 0;
            var newDenominationsCount = (int[])denominationsCount.Clone();
            for (int denominationCount = Math.Min(n / denominations[currentPos], denominationsCount[currentPos]);
                denominationCount >= 0; denominationCount--)
                if (denominations[currentPos] * denominationCount <= n)
                {
                    newDenominationsCount[currentPos] -= denominationCount;
                    result += GetCombinations(n - denominations[currentPos] * denominationCount, currentPos - 1,
                        newDenominationsCount);
                    newDenominationsCount[currentPos] += denominationCount;
                }

            return map[newMap] = result;
        }
    }
}
