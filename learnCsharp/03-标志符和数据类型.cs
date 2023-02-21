using System;

class Identifier
{
    public static void run()
    {
        var @x = 3; //标志符可以是at开头
        var @if = "hello";
        Console.WriteLine(@x + @if);
        // byte x = 123;//不能再定义x，因为与@x冲突
        //有符号整数系列
        sbyte @sbyte = 13; //有符号byte
        short @short; //16bit有符号整数
        int @int; //32bit有符号整数
        long @long; //64bit有符号整数
        //无符号整数系列
        byte @byte = 13;
        ushort @ushort;
        uint @uint; //32bit无符号整数
        ulong @ulong; //64bit无符号整数


        //另一种整数写法
        UInt16 @Uint16;
        Int16 @Int16;
        UInt32 @uint32;
        Int32 @Int32;
        UInt64 @uint64;
        Int64 @Int64;
        Decimal @Decimal;

        char @char = 'c';
        double @double = 3.0;
        float @float = 3f;
        decimal @decimal = 1 << 128; //128位高精度浮点数


        //一切皆object
        Object o = 100;
        //动态类型
        dynamic any = 3;
        any = "hello";
        //字符串类型
        String s = "hello";
        string ss = "hello";
        //多行字符串
        string sss = @"天下大势
为我所控";
        sss = $"{s}{sss}"; //直接拼串
        Console.WriteLine($"{s}{sss}{@double}");

        IntPtr @intPtr;
        //在使用unsafe的情况下可以使用指针
        unsafe
        {
            int* intptr;
        }


        //常量定义
        int num = 212;
        uint numUint = 123u;
        long numLong = 0xFee; //十六进制
        long numLong2 = 0xFEe; //十六进制
        long numLong3 = 1234l; //推荐使用大写的L，因为小写的l容易跟1混淆
        numLong3 = 1234L;
        num = 023; //八进制
        num = 0b011; //二进制
        @float = 3.13f;
        @float = .13f;
        @double = 0.1e13;
        @double = 1E-9; //E大小写都行

        //定义常量
        const int num4 = 10;

        //可空数据类型
        int? num5 = null;
        int? num6 = 45;
        double? num7 = new double?();
        double? num8 = 3.14157;
        num8 = num6 ?? 5.34; //如果num6为空则采用第二个值
        num8 = num6 == null ? 5.34 : (double) num6;

        char[] aa = {'a', 'b', 'c'};
        string ssss = new string(aa);
        ssss = String.Join(s, ss, sss);

        //C#支持元组类型
        var position = (1, 2, 3);
        //使用元祖实现匿名结构体的效果
        (double Sum, int Count) t2 = (4.5, 3);
        Console.WriteLine($"Sum of {t2.Count} elements is {t2.Sum}.");
    }

    public static void testString()
    {
        //C#中的字符串可以直接判等
        var a = "ab" + "c";
        var b = "a" + "bc";
        Console.WriteLine($"{a == b} {a.Equals(b)}");
    }
}