using System;
using System.Collections.Generic;
using System.Text;
/**
 * C#和Java都抛弃了复杂的C++运算符重载，但是C#保留了下标运算符重载，并给它
 * 另取了一个名字叫做：索引器。
 *
 */
class Users
{
    private List<string> users;

    Users()
    {
        users = new List<string>();
    }

    public void AddUser(string user)
    {
        users.Add(user);
    }

    public string this[int index]
    {
        get { return users[index]; }
        set { users[index] = value; }
    }

    //下标运算符支持函数重载
    public string this[string index]
    {
        get
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i] == index)
                {
                    return index;
                }
            }

            return "";
        }
        set
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i] == value)
                {
                    users[i] = value;
                }
            }
        }
    }

    public override string ToString()
    {
        StringBuilder s = new StringBuilder();
        foreach (var i in users)
        {
            s.Append(i + ",");
        }

        return s.ToString();
    }

    public static void TestOperator()
    {
        Users a = new Users();
        a.AddUser("one");
        a.AddUser("two");
        Console.WriteLine(a.ToString());
        a[0] = "three";
        Console.WriteLine(a.ToString());
        a["three"] = "four";
        Console.WriteLine(a.ToString());
        Console.WriteLine(a["four"]);
    }
}