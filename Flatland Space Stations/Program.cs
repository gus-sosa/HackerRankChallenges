using System;
using System.Linq;

namespace Flatland_Space_Stations
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();
            int n = int.Parse(tokens[0]);
            int m = int.Parse(tokens[1]);
            int[] cities = Console.ReadLine().Split().Select(token => int.Parse(token)).ToArray();
            Array.Sort(cities);

            if (n == m) Console.WriteLine(0);
            else
            {
                int maxDst = 0;
                for (int i = 0; i < cities.Length; i++)
                {
                    int currentCity = cities[i];
                    int previousCity = i - 1 >= 0 ? cities[i - 1] : -1;
                    int nextCity = i + 1 < cities.Length ? cities[i + 1] : -1;
                    int currentCityMaxDst = 0;

                    if (previousCity == -1)
                        currentCityMaxDst = currentCity;
                    else
                        currentCityMaxDst = Math.Max(currentCityMaxDst, (currentCity + previousCity) / 2 - currentCity);

                    if (nextCity == -1)
                        currentCityMaxDst = Math.Max(currentCityMaxDst, n - 1 - currentCity);
                    else
                        currentCityMaxDst = Math.Max(currentCityMaxDst, (nextCity + currentCity) / 2 - currentCity);

                    maxDst = Math.Max(maxDst, currentCityMaxDst);
                }

                Console.WriteLine(maxDst);
            }
        }
    }
}
