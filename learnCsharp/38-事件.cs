using System;

class EventIsDelegate
{
    delegate void OnClick();

    class Button
    {
        public int clickCount;
        public OnClick OnClick;

        public void click()
        {
            if (this.OnClick != null)
            {
                this.OnClick();
            }
        }
    }

    public static void TestEvent()
    {
        Button b = new Button();
        b.click(); //output nothing
        b.OnClick += delegate { Console.WriteLine($"按钮被点击{b.clickCount}次"); };
        b.OnClick += delegate { Console.WriteLine($"按钮被点击{b.clickCount}次"); };
        b.click(); //output two times
        b.OnClick = null;
        Console.WriteLine("从头再来");
        OnClick onclick = delegate { Console.WriteLine($"按钮被点击{b.clickCount}次"); };
        b.OnClick += onclick;
        b.OnClick += onclick;
        b.click(); //output two times
    }
}

public class EventTest2
{
    public class Publisher
    {
        // Declare the delegate (if using non-generic pattern).
        public delegate void SampleEventHandler(object sender, string e);

        // Declare the event.
        public event SampleEventHandler SampleEvent;

        // Wrap the event in a protected virtual method
        // to enable derived classes to raise the event.
        public void RaiseSampleEvent()
        {
            // Raise the event in a thread-safe manner using the ?. operator.
            SampleEvent?.Invoke(this, new string("Hello"));
        }
    }

    public class Subscriber
    {
        private static int id;
        public int ID;

        public Subscriber()
        {
            this.ID = id++;
        }

        public void handle(object sender, string s)
        {
            Console.WriteLine($"{ID} handle {s}");
        }
    }

    public static void TestEvent()
    {
        Publisher pub = new Publisher();
        Subscriber x = new Subscriber();
        Subscriber y = new Subscriber();
        pub.SampleEvent += x.handle;
        pub.SampleEvent += y.handle;
        pub.RaiseSampleEvent();
    }
}

public class TestAction
{
    public static void ActionAdd()
    {
        Action one = () => { Console.WriteLine("one"); };
        Action two = () => { Console.WriteLine("two"); };
        one += two;
        one.Invoke();
        Console.WriteLine("===========");
        Action three = null;
        three += one;
        three += two;
        three.Invoke();
    }

    public static void ActionAdd2()
    {
        Action one = () => { Console.WriteLine("one"); };
        Action two = () => { Console.WriteLine("two"); };
        var four = one + two;
        four.Invoke();
        four(); //直接使用括号就能够执行
    }
}