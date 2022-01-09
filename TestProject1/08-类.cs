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

    public static void main()
    {
        User u = new User();
    }
}