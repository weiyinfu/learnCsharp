using System;

class UseClass
{
    sealed class User //不可继承的类
    {
        public User()
        {
            Console.WriteLine("user is created");
        }

        ~User()
        {
            Console.WriteLine("user is deleted");
        }
    }

    abstract class Animal //定义一个抽象类
    {
        public abstract void shout();
    }

    class Dog : Animal //集成一个类
    {
        public override void shout()
        {
            throw new NotImplementedException();
        }
    }

    interface IShoutAnimal
    {
        void shout();
    }

    interface IRunAnimal
    {
        void run();
    }

    class Cat : IShoutAnimal, IRunAnimal
    {
        public void shout()
        {
            throw new NotImplementedException();
        }

        public void run()
        {
            throw new NotImplementedException();
        }
    }

    //使用属性和构造函数
    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y) => (X, Y) = (x, y);
    }

//使用泛型
    public class Pair<TFirst, TSecond>
    {
        public TFirst First { get; }
        public TSecond Second { get; }

        public Pair(TFirst first, TSecond second) =>
            (First, Second) = (first, second);
    }

    public static void testClass()
    {
        User u = new User();
    }
}