using System;
using System.Linq;
namespace ConnectingTowns {
    class Program {
        static void Main(string[] args) {
            int t = int.Parse(Console.ReadLine()), n = 0;
            int m = 1234567;
            while (t-- != 0) {
                n = int.Parse(Console.ReadLine());
                Console.WriteLine(Console.ReadLine()
                                    .Split(' ')
                                    .Select(v => int.Parse(v))
                                    .Aggregate((current, aggre) => current * aggre % m));
            }
        }
    }
}
