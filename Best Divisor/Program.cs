using System;
class Solution
{

    static void Main(String[] args)
    {
        Sum(100);
        int n = Convert.ToInt32(Console.ReadLine());
        int maxSum = 1;
        int maxDiv = 1;
        for (int currentNum = 2; currentNum <= n; currentNum++)
            if (n % currentNum == 0)
            {
                int currentSum = Sum(currentNum);
                if (currentSum > maxSum)
                {
                    maxDiv = currentNum;
                    maxSum = currentSum;
                }
            }

        Console.WriteLine(maxDiv);
    }

    private static int Sum(int currentNum)
    {
        int sum = 0;
        while (currentNum >= 10)
        {
            sum += currentNum % 10;
            currentNum /= 10;
        }
        return sum + currentNum;
    }
}
