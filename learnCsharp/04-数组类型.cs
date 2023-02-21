using System;
using System.Collections.Generic;

class UseArray
{
    public static void TestUseArray()
    {
        int[,] a = new int[10, 10]; //这是一个紧凑的二维数组
        int[][] b = new int[10][]; //这是一个动态的二维数组

        /*如果没有给list指定初始大小，则默认为0，当第一次添加元素的时候变成4，之后满了就2倍扩充
         * 如果指定了list的初始大小，或者是设置了capacity，当满了的时候，会取2的幂次的上界
         *
         */
        var c = new List<int>();
        var capacityList = new List<int>();
        for (int i = 0; i < 10000; i++)
        {
            c.Add(i);
            if (capacityList.Count == 0 || c.Capacity != capacityList[capacityList.Count - 1])
            {
                capacityList.Add(c.Capacity);
                Console.Write($"{i}=>{c.Capacity},");
            }
        }

        var d = new List<int>();
        d.Capacity = 10000;
        capacityList.Clear();
        Console.WriteLine();
        Console.WriteLine(d.Capacity);
        for (int i = 0; i < 10000; i++)
        {
            c.Add(i);
            if (capacityList.Count == 0 || c.Capacity != capacityList[capacityList.Count - 1])
            {
                capacityList.Add(c.Capacity);
                Console.Write($"{i}=>{c.Capacity},");
            }
        }

        Console.WriteLine();
        d = new List<int>(100);
        Console.WriteLine($"{d.Capacity}");
    }
}