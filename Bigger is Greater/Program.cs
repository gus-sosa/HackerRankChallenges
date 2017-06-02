using System;

namespace Bigger_is_Greater
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                string word = Console.ReadLine();
                Console.WriteLine(GetAnswer(word) ?? "no answer");
            }
        }

        private static string GetAnswer(string word)
        {
            char[] array = word.ToCharArray();
            //computing next permutation
            int i = array.Length - 1;
            while (i > 0 && array[i - 1] >= array[i])
                i--;

            if (i <= 0)
                return null;

            int j = array.Length - 1;
            while (array[j] <= array[i - 1])
                j--;

            //swap
            char tmp = array[i - 1];
            array[i - 1] = array[j];
            array[j] = tmp;

            Array.Reverse(array, i, array.Length - i);
            return new string(array);
        }
    }
}