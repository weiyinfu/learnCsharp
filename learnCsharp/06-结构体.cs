using System;

class UseStructure
{
    struct User
    {
        public string name;
        public int age;
    }

    class User2
    {
        public string name;
        public int age;
    }

/*
 * Java里面一切皆引用
 * Golang里面有指针、有结构体
 * C# 同样是有结构体、有class，结构体是值，class是引用
 *
 * 结构和类的区别：
 * * 结构体是值，类是引用
 * * 结构体不能继承
 */
    public static void TestUseStructure()
    {
        User u = new User();
        u.name = "hello";
        u.age = 13;
        User v = u; //这里是复制了一份值
        u.age = 25;
        Console.WriteLine($"name={v.name} age={v.age} {v.name == u.name}");


        User2 uu = new User2();
        uu.name = "hello";
        uu.age = 13;
        User2 vv = uu; //这里是复制了一份值
        uu.age = 25; //更改age之后，vv的age也发生了改变
        Console.WriteLine($"name={vv.name} age={vv.age} {vv.name == uu.name}");
    }
}