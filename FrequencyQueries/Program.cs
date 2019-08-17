using System.Collections.Generic;
using System.Linq;
using System;
using System.Diagnostics;

class Solution {
  static Dictionary<int, int> numFreq = new Dictionary<int, int>();
  static Dictionary<int, int> freqNum = new Dictionary<int, int>();

  // Complete the freqQuery function below.
  static List<int> freqQuery(List<List<int>> queries) {
    var result = new List<int>();
    //Debugger.Launch();
    //int oper = 0;
    foreach (List<int> query in queries) {
      int operation = query[0];
      int data = query[1];
      switch (operation) {
        case 1:
          Insert(data);
          break;
        case 2:
          Delete(data);
          break;
        case 3:
          //++oper;
          //if (oper == 1423) {
          //  Debugger.Break();
          //}
          result.Add(Check(data));
          break;
        default:
          throw new NotImplementedException();
      }
    }
    return result;
  }

  private static int Check(int data) {
    return freqNum.ContainsKey(data) && freqNum[data] > 0 ? 1 : 0;
  }

  private static void Delete(int data) {
    if (numFreq.ContainsKey(data)) {
      int originalFreq = numFreq[data];
      numFreq[data] -= 1;
      if (numFreq[data] == 0) {
        numFreq.Remove(data);
      } else {
        UpdateFrequency(numFreq[data], 1);
      }
      UpdateFrequency(originalFreq, -1);
    }
  }

  private static void Insert(int data) {
    if (numFreq.ContainsKey(data)) {
      int originalFreq = numFreq[data];
      numFreq[data] += 1;
      UpdateFrequency(numFreq[data], 1);
      UpdateFrequency(originalFreq, -1);
    } else {
      numFreq[data] = 1;
      UpdateFrequency(1, 1);
    }
  }

  private static void UpdateFrequency(int freq, int incr) {
    if (freqNum.ContainsKey(freq)) {
      int newFreq = freqNum[freq] + incr;
      if (newFreq < 0) {
        throw new ApplicationException();
      } else if (newFreq == 0) {
        freqNum.Remove(freq);
      } else {
        freqNum[freq] = newFreq;
      }
    } else {
      if (incr < 1) {
        throw new ApplicationException();
      }
      freqNum[freq] = incr;
    }
  }

  static void Main(string[] args) {
    int q = Convert.ToInt32(Console.ReadLine().Trim());

    List<List<int>> queries = new List<List<int>>();

    for (int i = 0; i < q; i++) {
      queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
    }

    List<int> ans = freqQuery(queries);

    Console.WriteLine(String.Join("\n", ans));
  }
}
