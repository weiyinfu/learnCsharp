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
        var four = await getOne().ContinueWith(x =>
        {
            return x.Result + getTwo().ContinueWith(y =>
            {
                return y.Result + "haha";
            });
        });
        Console.WriteLine(four);
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