using System;
class Solution
{
    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
        string result = "";
        bool flag = false;
        int pos = 0;
        int rest = 0;
        while (!flag)
        {
            flag = true;
            int currentValue = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                var item = arr[i];
                if (item > 0)
                {
                    flag = false;
                    currentValue += item % 10;
                    arr[i] = item / 10;
                }
            }
            if (!flag)
            {
                currentValue += rest;
                rest = currentValue / 10;
                currentValue %= 10;
                result = $"{currentValue}{result}";
            }
        }
        if (rest > 0)
        {
            result = $"{rest}{result}";
        }
        Console.WriteLine(result);
    }
}
