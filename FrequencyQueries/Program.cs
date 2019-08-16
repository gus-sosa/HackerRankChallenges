using System.Collections.Generic;
using System.Linq;
using System;
using System.Diagnostics;

class Solution
{
  static Dictionary<int, int> numFreq = new Dictionary<int, int>();
  static Dictionary<int, int> freqNum = new Dictionary<int, int>();

  // Complete the freqQuery function below.
  static List<int> freqQuery(List<List<int>> queries) {
    var result = new List<int>();
    Debugger.Launch();
    int oper = 0;
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
          ++oper;
          if (oper == 1422) {
            Debugger.Break();
          }
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
      int freq = numFreq[data];
      if (freq == 1) {
        numFreq.Remove(data);
      } else {
        numFreq[data] -= 1;
      }
      if (freqNum.ContainsKey(freq)) {
        if (freqNum[freq] == 1) {
          freqNum.Remove(freq);
        } else {
          freqNum[freq] -= 1;
          if (!freqNum.ContainsKey(freq - 1)) {
            freqNum[freq - 1] = 1;
          } else {
            freqNum[freq - 1] += 1;
          }
        }
      }
    }
  }

  private static void Insert(int data) {
    bool hasPreviousFreq = false;
    if (!numFreq.ContainsKey(data)) {
      numFreq[data] = 1;
    } else {
      hasPreviousFreq = true;
      numFreq[data] += 1;
    }
    int freq = numFreq[data];
    if (!freqNum.ContainsKey(freq)) {
      freqNum[freq] = 1;
    } else {
      freqNum[freq] += 1;
    }
    if (hasPreviousFreq && freqNum.ContainsKey(freq - 1)) {
      freqNum[freq - 1] -= 1;
      if (freqNum[freq - 1] == 0) {
        freqNum.Remove(freq - 1);
      }
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
