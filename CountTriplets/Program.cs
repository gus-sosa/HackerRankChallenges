using System;
using System.Collections.Generic;
using System.Diagnostics;

class Solution
{
    private static long _countTriplets;
    private static Dictionary<long, long> _tuples;
    private static Dictionary<long, long> _singles;


    // Complete the countTriplets function below.
    static long countTriplets(long[] arr, long r)
    {
        Debugger.Launch();
        _countTriplets = 0;
        _tuples = new Dictionary<long, long>();
        _singles = new Dictionary<long, long>();

        foreach (var currentNum in arr)
            if (IsPowerOfRatio(currentNum, r))
            {
                AggregateTriplets(currentNum, r);
                AggregateDoubles(currentNum, r);
                AggregateSingles(currentNum);
            }

        return _countTriplets;
    }

    private static void AggregateSingles(long num)
    {
        if (!_singles.ContainsKey(num))
            _singles[num] = 0;
        ++_singles[num];
    }

    private static void AggregateDoubles(long currentNum, long ratio)
    {
        var previousInProgression = PreviousInProgression(currentNum, ratio);
        if (_singles.ContainsKey(previousInProgression))
            AddTupletes(currentNum, _singles[previousInProgression]);
    }

    private static void AddTupletes(long endTuplete, long cant)
    {
        if (!_tuples.ContainsKey(endTuplete))
            _tuples[endTuplete] = 0;
        _tuples[endTuplete] += cant;
    }

    private static void AggregateTriplets(long num, long ratio) => _countTriplets += (_tuples.ContainsKey(PreviousInProgression(num, ratio)) ? _tuples[PreviousInProgression(num, ratio)] : 0);

    private static long PreviousInProgression(long num, long ratio) => num / ratio;

    private static bool IsPowerOfRatio(long num, long ratio) => (ratio == 1 && num == 1) || (num == 1 && ratio > 1) ||
        (num % ratio == 0 && long.TryParse(Math.Log(num, ratio).ToString(), out _));

    static void Main(string[] args)
    {
        string[] nr = Console.ReadLine().Split(' ');

        long n = Convert.ToInt64(nr[0]);

        long r = Convert.ToInt64(nr[1]);

        long[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt64(arrTemp))
        ;
        long ans = countTriplets(arr, r);

        Console.WriteLine(ans);
    }
}
