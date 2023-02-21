using System;
using NUnit.Framework;

namespace learnCsharp
{
    [TestFixture]
    public class PrintLittle99
    {
        [Test]
        public void 打印小九九()
        {
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("{0}*{1}={2} ", i, j, i * j);
                }

                Console.WriteLine();
            }
        }
    }
}