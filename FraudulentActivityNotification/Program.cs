using System;
using System.Diagnostics;

class Solution
{

    // Complete the activityNotifications function below.
    static int activityNotifications(int[] expenditure, int d)
    {
        //Debugger.Launch();

        int numNotifications = 0;
        for (int i = d; i < expenditure.Length; i++)
            if (RaiseNotification(ComputeMedian(expenditure, i - d, i - 1), expenditure[i]))
                numNotifications++;
        return numNotifications;
    }

    private static int ComputeMedian(int[] expenditure, int iStart, int iEnd)
    {
        int length = iEnd - iStart + 1;
        Array.Sort(expenditure, iStart, length);
        int middleIndex = length / 2;
        return length % 2 == 0
            ? (expenditure[iStart + middleIndex - 1] + expenditure[iStart + middleIndex]) / 2
            : expenditure[iStart + middleIndex];
    }

    private static bool RaiseNotification(int median, int currentExpend) => currentExpend >= 2 * median;

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