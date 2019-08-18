using System;
using System.Linq;

namespace GoogleProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(GetUnique(arr));
            Console.ReadLine();
        }

        private static int GetUnique(int[] arr) => GetUnique(arr, 0, 0, arr.Length - 1).Value;

        private static int? GetUnique(int[] arr, int binaryPos, int iStart, int iEnd)
        {
            sortArray(arr, binaryPos, iStart, iEnd);
            (int numOnes, int numZeros) = countGroups(arr, binaryPos, iStart, iEnd);
            if (IsBaseCase(numOnes, numZeros))
                return null;
            if (IsBaseCase(numZeros, numOnes))
                return null;
            if (numOnes == 1)
                return arr[iStart];
            if (numZeros == 1)
                return arr[iEnd];
            return GetUnique(arr, binaryPos + 1, iStart, iStart + numOnes - 1) ??
                GetUnique(arr, binaryPos + 1, iStart + numOnes, iEnd);
        }

        private static void sortArray(int[] arr, int binaryPos, int iStart, int iEnd)
        {
            while (iStart < iEnd)
            {
                if (IsBitSet(arr[iStart], binaryPos)) iStart++;
                else swap(arr, iStart, iEnd--);
            }
        }

        private static void swap(int[] arr, int pos1, int pos2)
        {
            int tmp = arr[pos1];
            arr[pos1] = arr[pos2];
            arr[pos2] = tmp;
        }

        private static (int numOnes, int numZeros) countGroups(int[] arr, int binaryPos, int iStart, int iEnd)
        {
            int numOnes = 0, numZeros = 0;
            foreach (int num in arr.Where((_, index) => index >= iStart && index <= iEnd))
            {
                if (IsBitSet(num, binaryPos)) numOnes++;
                else numZeros++;
            }
            return (numOnes, numZeros);
        }

        private static bool IsBitSet(int num, int binaryPos) => (num & (1 << binaryPos)) != 0;

        private static bool IsBaseCase(int numGroup1, int numGroup2) => numGroup1 == 0 && numGroup2 == 3;
    }
}
