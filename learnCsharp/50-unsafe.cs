using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

/*
 * 编译不安全代码的时候，必须unsafe
 *csc /unsafe prog1.cs
 *
 */
namespace UnsafeCodeApplication
{
    class TestPointer
    {
        public unsafe void swap(int* p, int* q)
        {
            int temp = *p;
            *p = *q;
            *q = temp;
        }

        public static void Main2()
        {
            unsafe
            {
                int var = 20;
                int* p = &var;
                Console.WriteLine("Data is: {0} ", var);
                Console.WriteLine("Data is: {0} ", p->ToString());
                Console.WriteLine("Address is: {0} ", (int) p);
            }
        }

        public unsafe static void TestUnsafe()
        {
            TestPointer p = new TestPointer();
            int var1 = 10;
            int var2 = 20;
            int* x = &var1;
            int* y = &var2;

            Console.WriteLine("Before Swap: var1:{0}, var2: {1}", var1, var2);
            p.swap(x, y);

            Console.WriteLine("After Swap: var1:{0}, var2: {1}", var1, var2);
            Console.ReadKey();
        }

        public unsafe static void UsePointerToVisitArray()
        {
            int[] list = {10, 100, 200};
            fixed (int* ptr = list)
                /* 显示指针中数组地址 */
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("Address of list[{0}]={1}", i, (int) (ptr + i));
                    Console.WriteLine("Value of list[{0}]={1}", i, *(ptr + i));
                }
        }

        public static void useArray()
        {
            /*
             * C#的数组布局：
             * 数组地址-1，表示数组长度
             */
            var x = new int[10];
            unsafe
            {
                fixed (int* p = x)
                {
                    Console.WriteLine(*((long*) p - 1)); // 输出10，p表示数组的首地址，前面一个long表示数组的长度。
                }
            }
        }

        //在栈上手动分配空间
        public static void stackMalloc()
        {
            unsafe
            {
                var x = stackalloc int[2];
                x[0] = 3;
                x[1] = 5;
                Console.WriteLine($"{x[0] + x[1]}");
            }
        }

        //绕过GC手动在堆上申请内存，GC不会管理这段内存
        public static unsafe void handAlloc()
        {
            //Malloc
            var a = (int*) Marshal.AllocCoTaskMem(10 * sizeof(int));
            for (var i = 0; i < 10; i++)
            {
                a[i] = i;
            }

//Relloc
            a = (int*) Marshal.ReAllocCoTaskMem((IntPtr) a, 20 * sizeof(int));
            for (var i = 0; i < 20; i++)
            {
                Console.WriteLine(a[i]);
            }

            Marshal.FreeCoTaskMem((IntPtr) a);
        }

        //使用结构体实现Union，联合体
        [StructLayout(LayoutKind.Explicit)]
        struct Foo
        {
            [FieldOffset(0)] public int Int;
            [FieldOffset(0)] public float Float;
            [FieldOffset(0)] public unsafe fixed byte Bytes[4];
        }

        public static unsafe void useStruct()
        {
            var obj = new Foo();
            obj.Float = 1;
            Console.WriteLine(obj.Int); // 1065353216
            Console.WriteLine(obj.Bytes[0]); // 0
            Console.WriteLine(obj.Bytes[1]); // 0
            Console.WriteLine(obj.Bytes[2]); // 128
            Console.WriteLine(obj.Bytes[3]); // 63

            //直接从byte数组解析出一个C#结构体
            var data = stackalloc byte[] {0, 0, 128, 63};
            var foo = Unsafe.AsRef<Foo>(data);
            Console.WriteLine(foo.Float); // 1
        }
    }
}