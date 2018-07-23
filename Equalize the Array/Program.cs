using System;
using System.Linq;

namespace Equalize_the_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int.Parse(Console.ReadLine());//skipped the N value
            int[] array = Console.ReadLine().Split().Select(token => int.Parse(token)).ToArray();

            Array.Sort(array);
            int lengthMaxBlock = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int j = i + 1;
                while (j < array.Length && array[j] == array[j - 1])
                    j++;
                j--;

                int currentBlockLength = j - i + 1;
                if (currentBlockLength > lengthMaxBlock)
                    lengthMaxBlock = currentBlockLength;
                i = j;
            }
            Console.WriteLine(array.Length - lengthMaxBlock);
        }
    }
}