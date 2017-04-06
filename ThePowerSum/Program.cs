using System;
class Solution
{
    static int N;

    static void Main(String[] args)
    {
        int X = int.Parse(Console.ReadLine());
        N = int.Parse(Console.ReadLine());

        Console.WriteLine(Cant(X, int.MaxValue));
    }

    private static int Cant(int num, int min)
    {
        if (num == 0)
            return 1;

        int cant = 0;
        for (int i = Math.Min(min, Convert.ToInt32(Math.Floor(Math.Pow(num, 1 / (N * 1f))))); i > 0; i--)
            cant += Cant(Convert.ToInt32(num - Math.Pow(i, N)), i - 1);

        return cant;
    }
}