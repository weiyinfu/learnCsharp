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

    public static void Main()
    {
        int x = (int) Days.Sun;
        int y = (int) Days.Fri;
        Console.WriteLine("Sun = {0}", x);
        Console.WriteLine("Fri = {0}", y);
    }
}