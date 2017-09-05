using System;
class Solution
{
    const int MIN_GRADE_NO_ROUND = 38;
    const int DIFF = 3;
    const int MOD = 5;

    static int solve(int grade)
    {
        int nextMultiple = GetNextMultiple(grade);
        if (grade < MIN_GRADE_NO_ROUND)
            return grade;
        return Math.Abs(nextMultiple - grade) < DIFF ? nextMultiple : grade;
    }

    private static int GetNextMultiple(int grade)
    {
        int result = grade + 1;//next grade, which is a possible multiple of five
        for (int i = 1; i <= MOD && result % MOD != 0; i++)
            result++;
        return result;
    }

    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        for (int grades_i = 0; grades_i < n; grades_i++)
            Console.WriteLine(solve(int.Parse(Console.ReadLine())));
    }
}
