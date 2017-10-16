using System;

namespace Special_Multiple
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine(GetMul((ulong)n));
            }
        }

        private static ulong GetMul(ulong n)
        {
            for (int i = 1; true; i++)
            {
                ulong nineRep = GetNineRepresentation(i);
                if (nineRep % n == 0)
                    return nineRep;
            }
        }

        private static ulong GetNineRepresentation(int n)
        {
            return ulong.Parse(Convert.ToString(n, 2).Replace('1', '9'));
        }
    }
}
