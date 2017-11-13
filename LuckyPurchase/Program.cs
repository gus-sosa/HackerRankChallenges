using System;

namespace LuckyPurchase
{
    class Program
    {
        static void Main()
        {
            int bestPrice = int.MaxValue;
            string lapName = "-1";

            int n = int.Parse(Console.ReadLine());
            while (n-- > 0)
            {
                string[] tokens = Console.ReadLine().Split();
                string nameLaptop = tokens[0];
                int price = int.Parse(tokens[1]);

                if (CheckConstraint(price) && price < bestPrice)
                {
                    bestPrice = price;
                    lapName = nameLaptop;
                }
            }

            Console.WriteLine(lapName);
        }

        private static bool CheckConstraint(int price)
        {
            int countSevens = 0;
            int countFours = 0;
            int countOthers = 0;

            while (price > 0)
            {
                int currentDigit = price % 10;
                switch (currentDigit)
                {
                    case 4:
                        countFours++;
                        break;
                    case 7:
                        countSevens++;
                        break;
                    default:
                        countOthers++;
                        break;
                }
                price /= 10;
            }

            return countOthers == 0 && countFours > 0 && countFours == countSevens;
        }
    }
}
