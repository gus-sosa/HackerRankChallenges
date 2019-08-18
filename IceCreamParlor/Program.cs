using System;
using System.Collections.Generic;
using System.Linq;

internal class Solution
{
    private struct CostAndIndex
    {
        public int Cost { get; set; }
        public int Index { get; set; }

        public static int operator +(CostAndIndex c1, CostAndIndex c2) => c1.Cost + c2.Cost;
    }

    // Complete the whatFlavors function below.
    private static void whatFlavors(int[] cost, int money)
    {
        List<CostAndIndex> costAndIndexes = BuildCostIndexesList(cost);
        Tuple<int, int> posChoosen = whatFlavors(costAndIndexes, money);
        PrintResult(posChoosen);
    }

    private static void PrintResult(Tuple<int, int> posChoosen)
    {
        var minPos = Math.Min(posChoosen.Item1, posChoosen.Item2);
        var maxPos = Math.Max(posChoosen.Item1, posChoosen.Item2);
        Console.WriteLine($"{minPos} {maxPos}");
    }

    private static List<CostAndIndex> BuildCostIndexesList(int[] cost)
    {
        var costAndIndexes = cost.Select((value, index) => new CostAndIndex() { Cost = value, Index = index + 1 }).ToList();
        costAndIndexes.Sort(new CostIndexSorter());
        return costAndIndexes;
    }

    private static Tuple<int, int> whatFlavors(List<CostAndIndex> costAndIndexes, int money)
    {
        int iLeft = 0, iRight = costAndIndexes.Count - 1;
        while (iLeft < iRight)
        {
            var currentValue = costAndIndexes[iLeft] + costAndIndexes[iRight];
            if (currentValue == money)
                return Tuple.Create(costAndIndexes[iLeft].Index, costAndIndexes[iRight].Index);
            if (currentValue < money)
                iLeft++;
            else
                iRight--;
        }
        throw new InvalidOperationException("There is no solution");
    }

    private static void Main(string[] args)
    {
        var t = Convert.ToInt32(Console.ReadLine());

        for (var tItr = 0; tItr < t; tItr++)
        {
            var money = Convert.ToInt32(Console.ReadLine());
            var n = Convert.ToInt32(Console.ReadLine());
            var costsArr = Console.ReadLine().Split(' ').Where(v => !string.IsNullOrEmpty(v)).ToArray();
            var cost = Array.ConvertAll(costsArr, costTemp => Convert.ToInt32(costTemp));
            whatFlavors(cost, money);
        }
    }

    private class CostIndexSorter : IComparer<CostAndIndex>
    {
        public int Compare(CostAndIndex x, CostAndIndex y) => x.Cost.CompareTo(y.Cost);
    }
}