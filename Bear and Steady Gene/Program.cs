using System;
class Solution
{
    class Counter
    {
        public int A { get; set; }
        public int C { get; set; }
        public int T { get; set; }
        public int G { get; set; }
        public int Limit { get; set; }

        private void ChangeQuantity(char v, int q)
        {
            switch (v)
            {
                case 'A':
                    A += q;
                    break;
                case 'C':
                    C += q;
                    break;
                case 'T':
                    T += q;
                    break;
                case 'G':
                    G += q;
                    break;
                default:
                    break;
            }
        }

        internal void Decrease(char v)
        {
            ChangeQuantity(v, -1);
        }

        internal bool IsFine()
        {
            return A <= Limit && C <= Limit && G <= Limit && T <= Limit;
        }

        internal void Increase(char v)
        {
            ChangeQuantity(v, 1);
        }
    }

    static void Main(String[] args)
    {
        Console.ReadLine();//skipping n
        string cad = Console.ReadLine();
        Console.WriteLine(LengthLessSubStr(cad));
    }

    private static int LengthLessSubStr(string cad)
    {
        var counter = new Counter()
        {
            Limit = cad.Length / 4
        };
        int i = -1;
        while (i < cad.Length && counter.IsFine())
            counter.Increase(cad[++i]);
        if (i < cad.Length)
            counter.Decrease(cad[i]);
        int j = cad.Length;
        while (i <= j && counter.IsFine())
            counter.Increase(cad[--j]);
        if (j >= 0)
            counter.Decrease(cad[j]);
        return i <= j ? j - i + 1 : 0;
    }
}