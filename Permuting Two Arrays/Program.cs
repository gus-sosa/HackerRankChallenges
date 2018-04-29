using System;
using System.Collections.Generic;
class Solution
{

    static string twoArrays(int k, int[] A, int[] B)
    {
        var sortedList = new List<int>(B);
        sortedList.Sort();
        for (int i = 0; i < A.Length; i++)
        {
            int minV = k - A[i];
            int index = IndexMinValue(sortedList, minV);
            if (A[i] + sortedList[index] < k)
                return "NO";
            sortedList.RemoveAt(index);
        }

        return "YES";
    }

    private static int IndexMinValue(List<int> list, int minV)
    {
        int iStart = 0, iEnd = list.Count - 1, middle;
        while (iStart < iEnd)
        {
            middle = (iStart + iEnd) / 2;
            if (list[middle] == minV)
                return middle;

            if (list[middle] > minV) iEnd = middle;
            else iStart = middle+1;
        }

        return iStart;
    }

    static void Main(String[] args)
    {
        int q = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < q; a0++)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            string[] A_temp = Console.ReadLine().Split(' ');
            int[] A = Array.ConvertAll(A_temp, Int32.Parse);
            string[] B_temp = Console.ReadLine().Split(' ');
            int[] B = Array.ConvertAll(B_temp, Int32.Parse);
            string result = twoArrays(k, A, B);
            Console.WriteLine(result);
        }
    }
}
