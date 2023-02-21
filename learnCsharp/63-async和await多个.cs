using System;
using System.Threading;
using System.Threading.Tasks;

class UseAsyncAwait2
{
    public static void Go()
    {
        new UseAsyncAwait2().main();
        Thread.Sleep(10 * 1000);
    }

    async void main()
    {
        var one = await getOne();
        var two = await getTwo();
        var three = await getThree();
        Console.WriteLine($"{one} {two} {three}");
        Task.WaitAll(new Task[] {getOne(), getTwo(), getThree()});
        var four = await getOne().ContinueWith(async x =>
        {
            var yy = await getTwo().ContinueWith(y => { return y.Result + "haha"; });
            return x.Result + yy;
        });
        Console.WriteLine("why cannot reach here");
        four.Wait();
        Console.WriteLine(four.Result);
    }

    Task<string> getOne()
    {
        return Task.Run(() => { return "one"; });
    }

    Task<string> getTwo()
    {
        return Task.Run(() => { return "two"; });
    }

    Task<string> getThree()
    {
        return Task.Run(() => { return "three"; });
    }
}