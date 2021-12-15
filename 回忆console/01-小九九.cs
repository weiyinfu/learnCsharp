using System;

public class Jiujiu
{
    public static void Main()
    {
        for(int i = 1; i <= 9; i++)
        {
            for(int j = 1; j <= i; j++)
            {
                Console.Write("{0}*{1}={2} ", i, j, i * j);
            }
            Console.WriteLine();
        }
        Console.WriteLine("x");
    }
}