using System;
class Solution
{
    static void Main(String[] args)
    {
        int n = int.Parse(Console.ReadLine());
        while (n-- > 0)
        {
            string cad = Console.ReadLine();
            Console.WriteLine(CountDeletions(cad));
        }
    }

    private static int CountDeletions(string cad)
    {
        int count = 0;

        for (int i = 0; i < cad.Length; i++)
        {
            int j = i + 1;
            while (j < cad.Length && cad[i] == cad[j])
                j++;
            count += j - i - 1;
            i = j - 1;
        }

        return count;
    }
}