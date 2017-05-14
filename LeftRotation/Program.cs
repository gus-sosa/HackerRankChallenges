using System;
namespace LeftRotation {
    class Program {
        static void Main(string[] args) {
            int n, d;
            string[] array = Console.ReadLine().Split(' ');
            n = Convert.ToInt32(array[0]);
            d = Convert.ToInt32(array[1]);
            array = Console.ReadLine().Split(' ');
            d = d % n;
            if (d == 0) {
                foreach (var item in array) {
                    Console.Write(item+" ");
                }
            } else {
                for (int i = d; i < array.Length; i++) {
                    Console.Write(array[i]+" ");
                }
                for (int i = 0; i < d; i++) {
                    Console.Write(array[i]+" ");
                }
            }
            Console.WriteLine();
        }
    }
}
