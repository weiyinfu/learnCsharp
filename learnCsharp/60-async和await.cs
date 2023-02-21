using System;
using System.Threading;
using System.Threading.Tasks;
/**
 * Csharp中的Task就相当于JavaScript中的Promise。
 *
 */
public class UseAsyncAwait
{
    public static void TestAsyncAwait()
    {
        new UseAsyncAwait().OnClick();
        Thread.Sleep(1000 * 10);
    }

    void OnClick()
    {
        Console.WriteLine("111 balabala. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
        AsyncMethod();
        Console.WriteLine("222 balabala. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
    }

    private async Task AsyncMethod()
    {
        var ResultFromTimeConsumingMethod = TimeConsumingMethod();
        string Result = await ResultFromTimeConsumingMethod + " + AsyncMethod. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId;
        Console.WriteLine(Result);
        //返回值是`Task`的函数可以不用`return`，或者将`Task`改为void
    }

//这个函数就是一个耗时函数，可能是`IO`操作，也可能是`cpu`密集型工作。
    private Task<string> TimeConsumingMethod()
    {
        var task = Task.Run(() =>
        {
            Console.WriteLine("Helo I am TimeConsumingMethod. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            Console.WriteLine("Helo I am TimeConsumingMethod after Sleep(5000). My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
            return "Hello I am TimeConsumingMethod";
        });
        return task;
    }
}