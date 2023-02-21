#define DEBUG
#undef DEBUG
using System;
using System.Diagnostics;
/*
 *使用Conditional 编译开关实现条件编译
 *
 */
public class Myclass
{
    [Conditional("DEBUG")]
    public static void Message(string msg)
    {
        Console.WriteLine(msg);
    }
}

class Test
{
    static void function1()
    {
        Myclass.Message("In Function 1.");
        function2();
    }

    static void function2()
    {
        Myclass.Message("In Function 2.");
    }

    public static void TestAttribute()
    {
        Myclass.Message("In Main function.");
        function1();
        Console.ReadKey();
    }
}
/**
 *Obsolte已废弃
 *
 */
public class UseObsolete
{
    [Obsolete("Don't use OldMethod, use NewMethod instead", true)]
    static void OldMethod()
    {
        Console.WriteLine("It is the old method");
    }
    static void NewMethod()
    {
        Console.WriteLine("It is the new method");
    }
    public static void TestUseAttribute2()
    {
        //这行代码无法运行
        // OldMethod();
    }
}