using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM_ICPC_Team
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();
            int n = int.Parse(tokens[0]);

            string[] matrix = new string[n];
            for (int i = 0; i < n; i++)
                matrix[i] = Console.ReadLine();

            int maxKnowledge = 0;
            int countTeamWithMaxKnowledge = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    string iKnowledge = matrix[i];
                    string jKnowledge = matrix[j];
                    int countKnowledge = CountKnowledge(iKnowledge, jKnowledge);

                    if (countKnowledge > maxKnowledge)
                    {
                        maxKnowledge = countKnowledge;
                        countTeamWithMaxKnowledge = 1;
                    }
                    else if (maxKnowledge == countKnowledge)
                        countTeamWithMaxKnowledge++;
                }
            }

            Console.WriteLine(maxKnowledge);
            Console.WriteLine(countTeamWithMaxKnowledge);
        }

        private static int CountKnowledge(string iKnowledge, string jKnowledge)
        {
            int sum = 0;
            for (int i = 0; i < iKnowledge.Length; i++)
                sum += iKnowledge[i] == '1' || jKnowledge[i] == '1' ? 1 : 0;
            return sum;
        }
    }
}