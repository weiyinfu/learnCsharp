using System;

class Function
{
    static void swap(ref int x, ref int y)
    {
        int temp = x;
        x = y;
        y = temp;
    }

    static int getValue(int z, int x = 3, int y = 4)
    {
        return x;
    }

    static void getValue2(out int z, int x = 3, int y = 4)
    {
        z = x + y;
    }

    static int getSum(params int[] a)
    {
        int s = 0;
        foreach (var i in a)
        {
            s += i;
        }

        return s;
    }

    public static void TestSwap()
    {
        int x = 3, y = 2;
        (x, y) = (y, x); //没必要实现swap函数
        Console.WriteLine($"{x},{y}");
        swap(ref x, ref y);
        Console.WriteLine($"{x},{y}");

        //默认参数，默认参数只能在尾部有默认值
        Console.WriteLine($"{getValue(1)},{getValue(1, 2)},{getValue(1, 2, 3)}");
        int z;
        getValue2(out z);
        Console.WriteLine($"user out param: {z}");

        //变参数
        Console.WriteLine($"{getSum(1, 2, 3, 4, 5)}");
    }
}