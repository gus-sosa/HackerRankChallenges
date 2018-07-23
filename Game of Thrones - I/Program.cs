using System;
namespace Game_of_Thrones___I
{
    class Program
    {
        const int LENGTH_COUNTER = 26;
        static void Main(string[] args)
        {
            string cad = Console.ReadLine();
            int[] counter = new int[LENGTH_COUNTER];

            foreach (char c in cad)
                counter['z' - c]++;

            bool oddFound = false;
            foreach (var quantity in counter)
                if (quantity % 2 != 0)
                {
                    if (oddFound)
                    {
                        Console.WriteLine("NO");
                        return;
                    }

                    oddFound = true;
                }

            Console.WriteLine("YES");
        }
    }
}
