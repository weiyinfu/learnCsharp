using System;
using MyNamespace.MyNamespace.One.Two;

namespace MyNamespace
{
    namespace MyNamespace.One.Two
    {
        //可以直接定义多级namespace
        class M
        {
            public static void echo()
            {
                Console.WriteLine("hello");
            }
        }
    }

    class T
    {
        public static void main()
        {
            #region 第一部分

            M.echo();

            #endregion
        }
    }
}