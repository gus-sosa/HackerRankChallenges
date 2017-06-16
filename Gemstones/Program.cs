using System;
using System.Collections.Generic;

namespace Gemstones
{
    class Program
    {
        static int gemstones(string[] arr)
        {
            if (arr != null && arr.Length == 0)
                return 0;

            HashSet<char> setLetters = GetSetLetters(arr[0]);
            for (int i = 1; i < arr.Length && setLetters.Count > 0; i++)
            {
                HashSet<char> otherSetLetters = GetSetLetters(arr[i]);
                setLetters = CommonSet(setLetters, otherSetLetters);
            }

            return setLetters.Count;
        }

        private static HashSet<char> CommonSet(HashSet<char> setLetters, HashSet<char> otherSetLetters)
        {
            var result = new HashSet<char>();
            foreach (var item in setLetters)
                if (otherSetLetters.Contains(item))
                    result.Add(item);

            return result;
        }

        private static HashSet<char> GetSetLetters(string v)
        {
            var set = new HashSet<char>();
            foreach (var item in v)
                if (!set.Contains(item))
                    set.Add(item);
            return set;
        }

        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr = new string[n];
            for (int arr_i = 0; arr_i < n; arr_i++)
            {
                arr[arr_i] = Console.ReadLine();
            }
            int result = gemstones(arr);
            Console.WriteLine(result);
        }
    }
}
