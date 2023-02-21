using System;

class UseProperty
{
    public static string name
    {
        get { return "haha"; }
    }


    private int age;

    // 声明类型为 int 的 Age 属性
    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public static void TestProperty()
    {
        Console.WriteLine($"{name}");
    }
}