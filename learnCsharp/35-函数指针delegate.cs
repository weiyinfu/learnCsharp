using System;

class UseDelegate
{
    delegate void PrintMethod(string s);

    public static void TestUseDelegate()
    {
        PrintMethod p1 = new PrintMethod(s => { Console.WriteLine("PrintMethod1:" + s); });
        PrintMethod p2 = new PrintMethod(s => { Console.WriteLine("PrintMethod2:" + s); });
        p1("hello");
        p2("hello");
        //多播，多播就是把多个函数指针串联起来，它是有序的
        var p3 = p1 + p2;
        p3("hello");
        p3 -= p1;
        p3 += p1;
        p3("hello"); //现在p1和p2的顺序反过来了
    }
}