using System;
using System.Linq;
class Solution
{
    static int inversions = 0;

    static void Main(String[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = arr_temp.Select(i => Convert.ToInt32(i)).ToArray();
            inversions = 0;
            MergeSort(arr);
            Console.WriteLine(inversions);
        }
    }

    private static void MergeSort(int[] arr)
    {
        MergeSortRecur(arr, 0, arr.Length - 1);
    }

    private static void MergeSortRecur(int[] arr, int iStart, int iEnd)
    {
        if (iStart >= iEnd)
            return;

        int mid = (iEnd + iStart) / 2;
        if (iEnd - iStart > 1)
        {
            MergeSortRecur(arr, iStart, mid);
            MergeSortRecur(arr, mid + 1, iEnd);
        }
        Merge(arr, iStart, mid, mid + 1, iEnd);
    }

    private static void Merge(int[] arr, int iStartLeft, int iEndLeft, int iStartRight, int iEndRigth)
    {
        int[] tmp = new int[iEndRigth - iStartLeft + 1];
        int indexToCopy = iStartLeft;
        int currentIndex = 0;
        while (iStartLeft <= iEndLeft && iStartRight <= iEndRigth)
        {
            bool comp = arr[iStartLeft] <= arr[iStartRight];
            if (!comp)
                inversions += iEndLeft - iStartLeft + 1;
            tmp[currentIndex++] = comp ? arr[iStartLeft++] : arr[iStartRight++];
        }

        while (iStartLeft <= iEndLeft)
        {
            tmp[currentIndex++] = arr[iStartLeft++];
        }

        while (iStartRight <= iEndRigth)
        {
            tmp[currentIndex++] = arr[iStartRight++];
        }

        for (int i = 0; i < tmp.Length; i++)
        {
            arr[indexToCopy++] = tmp[i];
        }
    }

    private static void Swap(ref int v1, ref int v2)
    {
        int tmp = v1;
        v1 = v2;
        v2 = tmp;
    }
}
