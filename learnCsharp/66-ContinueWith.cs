using System;
using System.Threading.Tasks;

public class ProgramTest
{
    public static void Test1()
    {
        var res = Task.Factory.StartNew(Calculate).ContinueWith(task =>
        {
            Task.WaitAll();
            return "hello world";
        });
        Console.WriteLine(res);
        Console.ReadLine();
    }

    private static void Calculate()
    {
        for (var number = 0; number < 1000; number++)
        {
            Console.WriteLine(number);
        }
    }
}