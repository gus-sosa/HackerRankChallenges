using System;

namespace FlippingBits
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                uint v = uint.Parse(Console.ReadLine());
                Console.WriteLine(~v);
            }
        }
    }
}
