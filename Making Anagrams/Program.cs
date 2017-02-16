using System;
namespace Making_Anagrams {
    class Program {
        static void Main(string[] args) {
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            int sizeCounters = 'z' - 'a' + 1;
            int[] counterA = new int[sizeCounters];
            int[] counterB = new int[sizeCounters];
            foreach (var item in a) {
                counterA['z' - item]++;
            }
            foreach (var item in b) {
                counterB['z' - item]++;
            }
            ulong total = 0;
            for (int i = 0; i < counterA.Length; i++) {
                total += (uint)Math.Abs(counterA[i] - counterB[i]);
            }
            Console.WriteLine(total);
        }
    }
}