using System;

internal class Solution
{
    private static void Main(string[] args)
    {
        //Debugger.Launch();
        var cad1 = Console.ReadLine();
        var cad2 = Console.ReadLine();

        var dict = new int[cad1.Length + 1 , cad1.Length + 1];
        for (var i = 0 ; i < cad1.Length ; i++)
            dict[0 , i] = dict[i , 0] = 0;
        for (var i = 0 ; i < cad1.Length ; i++)
            for (var j = 0 ; j < cad2.Length ; j++)
                dict[i + 1 , j + 1] = cad1[i] == cad2[j] ? dict[i , j] + 1 : Math.Max(dict[i , j + 1] , dict[i + 1 , j]);
        Console.WriteLine(dict[cad1.Length , cad1.Length]);
    }
}
