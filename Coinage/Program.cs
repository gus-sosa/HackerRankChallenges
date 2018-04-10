using System;
using System.Linq;

namespace Coinage
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                int n = int.Parse(Console.ReadLine());
                int[] denominationsCount = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int onelen = denominationsCount[0],
                    twolen = denominationsCount[1],
                    fivelen = denominationsCount[2],
                    tenlen = denominationsCount[3];
                int count = 0;
                for (int ten = 0; ten <= tenlen && 10 * ten <= n; ten++)
                    for (int five = 0; five <= fivelen && 10 * ten + 5 * five <= n; five++)
                        for (int two = 0; two <= twolen && 10 * ten + 5 * five + 2 * two <= n; two++)
                            if (n - (10 * ten + 5 * five + 2 * two) <= onelen)
                                count++;
                Console.WriteLine(count);
            }
        }
    }
}
