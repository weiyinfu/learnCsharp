using System;
using System.Threading;
using System.Threading.Tasks;

namespace learnCsharp
{
    public class UseCompletionSource
    {
        static Task<int> getUserCount()
        {
            TaskCompletionSource<int> y = new TaskCompletionSource<int>();

            //异步网络请求获取在线人数
            new Thread(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                y.SetResult(3);
            }).Start();
            return y.Task;
        }

        static Task<int> getUserCount2()
        {
            return Task.Run(() => { return 3; });
        }

        static Task<int> getUserCount3()
        {
            TaskCompletionSource<int> y = new TaskCompletionSource<int>();

            //异步网络请求获取在线人数
            new Thread(() => { y.SetResult(3); }).Start();
            return y.Task;
        }

        public static async void test1()
        {
            var value = await getUserCount();
            Console.WriteLine(value);
            Console.ReadKey();
        }

/*
 * C#的async函数如果发现没有可以被执行的函数
 * Task没有处于执行状态，则会自动退出程序。
 * 
 */
        public static async void test2()
        {
            var res = await getUserCount().ContinueWith<string>((m, additionalData) =>
            {
                Console.WriteLine($"result={m.Result} additional data={additionalData}");
                return "asdfadsf";
            }, "123434");
            Console.WriteLine(res);
            Console.ReadKey();
        }

        public static async void test3()
        {
            var res = await getUserCount2().ContinueWith<string>((m, additionalData) =>
            {
                Console.WriteLine($"result={m.Result} additional data={additionalData}");
                return "asdfadsf";
            }, "123434");
            Console.WriteLine(res);
            Console.ReadKey();
        }

        public static async void test4()
        {
            var res = await getUserCount3().ContinueWith<string>((m, additionalData) =>
            {
                Console.WriteLine($"result={m.Result} additional data={additionalData}");
                return "asdfadsf";
            }, "123434");
            Console.WriteLine(res);
            Console.ReadKey();
        }

        public static async void test5()
        {
            var t = getUserCount2().ContinueWith<string>(m =>
            {
                Console.WriteLine($"result={m.Result} ");
                return "asdfadsf";
            });
            // t.Wait();
            var s = await t;
            Console.WriteLine(s);
            Console.ReadKey();
        }

        public static async void test6()
        {
            Console.WriteLine("hello");
            Console.ReadKey();
        }
    }
}