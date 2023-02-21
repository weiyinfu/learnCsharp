using System;

class UseEnum
{
    enum Days
    {
        Sun,
        Mon,
        tue,
        Wed,
        thu,
        Fri,
        Sat
    };

    public static void TestEnum()
    {
        int x = (int) Days.Sun;
        int y = (int) Days.Fri;
        Console.WriteLine("Sun = {0}", x);
        Console.WriteLine("Fri = {0}", y);

        //枚举强制类型转换
        Days dd = (Days) 100;
        Console.Write($"{dd}");
    }
}