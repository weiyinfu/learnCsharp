using System;
using System.Threading;
using System.Threading.Tasks;

class UseTaskCompletionSource
{
    class Request
    {
        private TaskCompletionSource<string> a;

        public async Task<string> Gen()
        {
            a = new TaskCompletionSource<string>();
            return await a.Task;
        }

        public void handle(string s)
        {
            a.SetResult(s);
        }
    }

    void run()
    {
        Request req = new Request();
        req.Gen().ContinueWith(x =>
        {
            Console.WriteLine(x.Result);
            Console.WriteLine(x.Result);
        });
        Thread.Sleep(1000 * 3);
        req.handle("hello");
    }

    async Task<string> runAsync()
    {
        Request req1 = new Request();
        Request req2 = new Request();
        new Thread(() =>
        {
            Thread.Sleep(1000 * 5);
            req1.handle("one");
            req2.handle("two");
        }).Start();

        var s1 = await req1.Gen();
        var s2 = await req2.Gen();
        return s1 + s2;
    }

    public static void Go()
    {
        new UseTaskCompletionSource().run();
        new UseTaskCompletionSource().runAsync().ContinueWith(s =>
        {
            Console.WriteLine("Run Async ");
            Console.WriteLine(s.Result);
        });

        Thread.Sleep(1000 * 10);
    }
}