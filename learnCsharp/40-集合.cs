using System;
using System.Collections;
using System.Collections.Generic;

class UseCollection
{
    public static void NoGeneric()
    {
        //不支持泛型的集合
        var a = new ArrayList(10);
        var b = new Hashtable();
        var e = new Stack();
        e.Push(1);
        int x = (int) e.Pop();
        Console.WriteLine(x);
        var f = new Queue();
    }

    public static void bitArray()
    {
        var a = new BitArray(1000);
        a[0] = true;
        a[100] = true;
        Console.WriteLine(a.Get(100));
    }

    public static void TestCollection()
    {
        //支持泛型的集合
        var a = new List<int>(); //数组
        var b = new LinkedList<int>(); //链表


        var d = new Dictionary<String, int>(); //Hashmap
        var e = new SortedDictionary<String, int>(); //TreeMap
        var c = new SortedList<String, int>(); //LinkedHashmap
        var f = new HashSet<int>();
        var g = new SortedSet<int>();
    }
}