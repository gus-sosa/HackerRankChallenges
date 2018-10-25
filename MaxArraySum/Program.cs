using System;
using System.Linq;

internal class Solution
{

    // Complete the maxSubsetSum function below.
    private static int maxSubsetSum(int[] arr)
    {
        //Debugger.Launch();

        if (arr.Length == 1)
            return arr[0];

        int prevPrevMax = arr[0], prevMax = Math.Max(arr[1] , arr[0]);
        var prevLastPosTaken = prevMax == arr[1];

        Tuple<int , bool> newMax = null;

        for (var i = 2 ; i < arr.Length ; i++)
        {
            newMax = computeSubsetSum(arr[i] , prevPrevMax , prevMax , prevLastPosTaken);
            prevPrevMax = prevMax;
            prevMax = newMax.Item1;
            prevLastPosTaken = newMax.Item2;
        }

        return prevMax;
    }

    private static Tuple<int , bool> computeSubsetSum(int num , int prevPrevMax , int prevMax , bool prevLastPosTaken)
    {
        var taken = false;
        var max = 0;
        var currentPrevSum = num + prevMax;
        var currentPrevPrevSum = num + prevPrevMax;

        if (prevLastPosTaken)
        {
            max = Enumerable.Max(new int[] { num , prevMax , currentPrevPrevSum });
            taken = max == num || max == currentPrevPrevSum;
        }
        else
        {
            max = Enumerable.Max(new int[] { num , prevMax , currentPrevSum , currentPrevPrevSum , prevMax , prevPrevMax });
            taken = max == num || max == currentPrevSum || max == currentPrevPrevSum;
        }

        return Tuple.Create(max , taken);
    }

    private static void Main(string[] args)
    {
        var n = Convert.ToInt32(Console.ReadLine());
        var arr = Array.ConvertAll(Console.ReadLine().Split(' ') , arrTemp => Convert.ToInt32(arrTemp));
        var res = maxSubsetSum(arr);
        Console.WriteLine(res);
    }
}
