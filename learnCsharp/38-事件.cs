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