using System;
using System.Collections.Generic;

internal class Solution
{
    private static void Main(string[] args)
    {
        //Debugger.Launch();
        var cad1 = Console.ReadLine();
        var cad2 = Console.ReadLine();
        var maxLength = GetMaxCommonLength(cad1 , cad2);
        Console.WriteLine(maxLength);
    }

    private static int GetMaxCommonLength(string cad1 , string cad2)
    {
        for (var length = 0 ; length < cad1.Length ; length++)
            foreach (List<int> seq in GetSeqToDelete(length , cad1.Length))
            {
                if (seq == null)
                    break;
                if (CanFindChildInOtherCad(cad1 , seq , cad2))
                    return cad1.Length - length;
            }
        return 0;
    }

    private static IEnumerable<List<int>> GetSeqToDelete(int lengthSeq , int lengthSet)
    {
        foreach (List<int> item in GetSeqToDeleteRec(new List<int>(lengthSeq) , 0 , lengthSet))
            yield return item;
    }

    private static IEnumerable<List<int>> GetSeqToDeleteRec(List<int> list , int indexInSet , int lengthSet)
    {
        if (list.Count == list.Capacity) yield return list;
        else
        {
            var lastIndexToTake = indexInSet + (list.Capacity - list.Count) - 1;
            if (lastIndexToTake < lengthSet)
            {
                foreach (List<int> item in GetSeqToDeleteRec(list , indexInSet + 1 , lengthSet))
                {
                    if (item == null)
                        break;
                    yield return item;
                }

                list.Add(indexInSet);
                foreach (List<int> item in GetSeqToDeleteRec(list , indexInSet + 1 , lengthSet))
                {
                    if (item == null)
                        break;
                    yield return item;
                }
                list.RemoveAt(list.Count - 1);
            }

            yield return null;
        }
    }

    private static bool CanFindChildInOtherCad(string cad1 , List<int> seq , string cad2)
    {
        var lastIndexInSeq = 0;
        var lastIndexInCad2 = 0;
        for (var i = 0 ; i < cad1.Length ; i++)
            if (lastIndexInSeq < seq.Count && seq[lastIndexInSeq] == i) lastIndexInSeq++;
            else
            {
                lastIndexInCad2 = cad2.IndexOf(cad1[i] , lastIndexInCad2);
                if (lastIndexInCad2 < 0)
                    return false;
                ++lastIndexInCad2;
            }

        return true;
    }
}
