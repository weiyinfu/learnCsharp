#define one //define只能放在第一行
#undef one
using System;

class PreprocessorCommand
{
    public static void main()
    {
#if one
        Console.log("one is defined");
#elif two
Console.log("two is defined");
        #error "不要这么做"//产生一个预编译阶段的error
            #warning "这么做有风险"//产生一个warning
#else
        Console.WriteLine("else");
#endif

        //使用运算符
#if (one==two)

#endif
        //使用region

#warning

        #region MyRegion

        #endregion

        //使用pragma
#pragma warning disable 169
        // 取消编号 169 的警告（字段未使用的警告）

#pragma warning restore 169
        // 恢复编号 169 的警告
    }
}