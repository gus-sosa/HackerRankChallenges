using System;
using System.Linq;

namespace Jumping_on_the_Clouds
{
    class Program
    {
        static void Main(string[] args)
        {
            int numClouds = Convert.ToInt32(Console.ReadLine());
            bool[] thunderClouds = Console.ReadLine().Split(' ').Select(token => token == "1").ToArray();

            int[] mins = new int[numClouds];
            mins[numClouds - 1] = 0;
            for (int i = numClouds - 2, minFirstCloud, minSecondCloud; i >= 0; i--)
            {
                minFirstCloud = int.MaxValue;
                if (i + 1 < numClouds && !thunderClouds[i + 1])
                    minFirstCloud = 1 + mins[i + 1];
                minSecondCloud = int.MaxValue;
                if (i + 2 < numClouds && !thunderClouds[i + 2])
                    minSecondCloud = 1 + mins[i + 2];
                mins[i] = Math.Min(minFirstCloud, minSecondCloud);
            }

            Console.WriteLine(mins[0]);
        }
    }
}
