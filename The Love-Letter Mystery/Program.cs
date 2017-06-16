using System;

namespace The_Love_Letter_Mystery
{
    class Program
    {
        static int theLoveLetterMystery(string s)
        {
            int count = 0;

            int length = s.Length / 2;
            for (int i = 0; i < length; i++)
            {
                int j = s.Length - i - 1;
                if (s[i] != s[j])
                    count += Math.Abs(s[i] - s[j]);
            }

            return count;
        }

        static void Main(string[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < q; a0++)
            {
                string s = Console.ReadLine();
                int result = theLoveLetterMystery(s);
                Console.WriteLine(result);
            }
        }
    }
}