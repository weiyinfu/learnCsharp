using System;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

//https://www.runoob.com/csharp/csharp-regular-expressions.html
[TestFixture]
public class Example
{
    public static void TestRegex()
    {
        string input = "1851 1999 1950 1905 2003";
        string pattern = @"(?<=19)\d{2}\b";

        foreach (Match match in Regex.Matches(input, pattern))
            Console.WriteLine(match.Value);
    }

    [Test]
    public void TestSplit()
    {
        var text = Regex.Split(@"
        
        nolieiap
NOLIIAPFFFFFFFFFFFFF
非消耗品坎坎坷坷扩扩扩扩扩扩扩扩扩
消耗品苏东坡我阿道夫第三方是多么佛
南妹安发大水瞥见评价胖虎
全新的sku
更新的sku非消耗品撒旦法师打发斯蒂芬
限量版皮肤ddddddddddddd
支付测试关闭adsf大师傅
充数的iap
充数的iap", "\\s+");
        Console.WriteLine(text.Length);
        foreach (var i in text)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("============");
        var b = text.Where(x => x.Length > 0).ToArray();
        foreach (var i in b)
        {
            Console.WriteLine(i);
        }
    }

    [Test]
    public static void ReverseReference()
    {
        //Regular Expression reverse reference
        var s = @"wrap
1234 every number with a <>:
one asd 343 34lll 2345lkjj
";
        var ss = Regex.Replace(s, "(\\d+)", "<$1>");
        Console.WriteLine(ss);
    }
}