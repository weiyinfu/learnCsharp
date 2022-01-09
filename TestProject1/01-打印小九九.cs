using System;
using NUnit.Framework;

namespace TestProject1
{

    [TestFixture]
    public class Tests
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