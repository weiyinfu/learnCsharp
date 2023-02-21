using System;
using System.Reflection;

//描述当前Attribute的用法，它可以作用于哪些东西
[AttributeUsage(AttributeTargets.Class |
                AttributeTargets.Constructor |
                AttributeTargets.Field |
                AttributeTargets.Method |
                AttributeTargets.Property,
    AllowMultiple = true)]
public class DeBugInfo : Attribute
{
    private int bugNo;
    private string developer;
    private string lastReview;
    public string message;

    public DeBugInfo(int bg, string dev, string d)
    {
        this.bugNo = bg;
        this.developer = dev;
        this.lastReview = d;
    }

    public int BugNo
    {
        get { return bugNo; }
    }

    public string Developer
    {
        get { return developer; }
    }

    public string LastReview
    {
        get { return lastReview; }
    }

    public string Message
    {
        get { return message; }
        set { message = value; }
    }
}

[DeBugInfo(49, "Nuha Ali", "10/10/2012", Message = "Unused variable")]
class Rectangle
{
    // 成员变量
    protected double length;
    protected double width;

    public Rectangle(double l, double w)
    {
        length = l;
        width = w;
    }

    [DeBugInfo(55, "Zara Ali", "19/10/2012",
        Message = "Return type mismatch")]
    public double GetArea()
    {
        return length * width;
    }

    [DeBugInfo(56, "Zara Ali", "19/10/2012")]
    public void Display()
    {
        Console.WriteLine("Length: {0}", length);
        Console.WriteLine("Width: {0}", width);
        Console.WriteLine("Area: {0}", GetArea());
    }
}

//使用反射获取注解的信息
class ExecuteRectangle
{
    public static void TestRectangel()
    {
        Rectangle r = new Rectangle(4.5, 7.5);
        r.Display();
        Type type = typeof(Rectangle);
        // 遍历 Rectangle 类的特性
        foreach (Object attributes in type.GetCustomAttributes(false))
        {
            DeBugInfo dbi = (DeBugInfo) attributes;
            if (null != dbi)
            {
                Console.WriteLine("Bug no: {0}", dbi.BugNo);
                Console.WriteLine("Developer: {0}", dbi.Developer);
                Console.WriteLine("Last Reviewed: {0}",
                    dbi.LastReview);
                Console.WriteLine("Remarks: {0}", dbi.Message);
            }
        }

        // 遍历方法特性
        foreach (MethodInfo m in type.GetMethods())
        {
            foreach (Attribute a in m.GetCustomAttributes(true))
            {
                DeBugInfo dbi = (DeBugInfo) a;
                if (null != dbi)
                {
                    Console.WriteLine("Bug no: {0}, for Method: {1}",
                        dbi.BugNo, m.Name);
                    Console.WriteLine("Developer: {0}", dbi.Developer);
                    Console.WriteLine("Last Reviewed: {0}",
                        dbi.LastReview);
                    Console.WriteLine("Remarks: {0}", dbi.Message);
                }
            }
        }
    }
}