using System;

class Solution
{
    private static int[] countSortTable = new int[201];
    // Complete the activityNotifications function below.
    static int activityNotifications(int[] expenditure, int d)
    {
        int numNotifications = 0;
        for (int i = 0; i < d; i++)
            countSortTable[expenditure[i]]++;
        for (int i = d; i < expenditure.Length; i++)
        {
            if (RaiseNotification(GetMedian(d), expenditure[i]))
                numNotifications++;
            countSortTable[expenditure[i]]++;
            countSortTable[expenditure[i - d]]--;
        }
        return numNotifications;
    }

    private static double GetMedian(int d) => d % 2 == 0 ? (GetMedianIndex(d / 2) + GetMedianIndex(d / 2 + 1)) / 2d : GetMedianIndex(d / 2 + 1);

    private static int GetMedianIndex(int index)
    {
        int count = 0, i = 0;
        for (; i < countSortTable.Length; i++)
            if (countSortTable[i] > 0)
                if (count + countSortTable[i] < index) count += countSortTable[i];
                else break;
        return i;
    }

    private static bool RaiseNotification(double median, int currentExpend) => currentExpend >= 2 * median;

    static void Main(string[] args)
    {
        string[] nd = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nd[0]);

        int d = Convert.ToInt32(nd[1]);

        int[] expenditure = Array.ConvertAll(Console.ReadLine().Split(' '), expenditureTemp => Convert.ToInt32(expenditureTemp))
            ;
        int result = activityNotifications(expenditure, d);

        Console.WriteLine(result);
    }
}