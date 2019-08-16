using System;
using System.Collections.Generic;

class Solution
{
  // Complete the countTriplets function below.
  static long countTriplets(long[] arr, long ratio) {
    Dictionary<long, long> js = new Dictionary<long, long>(), ks = new Dictionary<long, long>();
    long count = 0;

    foreach (var value in arr) {
      if (!ks.ContainsKey(value)) {
        ks[value] = 0;
      }
      count += ks[value];
      if (!js.ContainsKey(value)) {
        js[value] = 0;
      }
      if (!ks.ContainsKey(value * ratio)) {
        ks[value * ratio] = 0;
      }
      ks[value * ratio] += js[value];
      if (!js.ContainsKey(value * ratio)) {
        js[value * ratio] = 0;
      }
      ++js[value * ratio];
    }

    return count;
  }

  static void Main(string[] args) {
    string[] nr = Console.ReadLine().Split(' ');
    long n = Convert.ToInt64(nr[0]);
    long r = Convert.ToInt64(nr[1]);
    long[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt64(arrTemp));
    long ans = countTriplets(arr, r);
    Console.WriteLine(ans);
  }
}