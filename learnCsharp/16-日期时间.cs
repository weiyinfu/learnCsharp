using System;
using NUnit.Framework;

public class Util
{
    public static DateTime UnixEpoch = new DateTime(1970, 1, 1).ToLocalTime().ToUniversalTime();

    public static int GetUtcSeconds()
    {
        return DateTimeToSeconds(DateTime.Now);
    }

    public static long GetUtcMilliSeconds()
    {
        return DateTimeToMilliSeconds(DateTime.Now);
    }

    public static int DateTimeToSeconds(DateTime t)
    {
        Console.WriteLine($"{t} {UnixEpoch}");
        return (int) (t.ToUniversalTime() - UnixEpoch).TotalSeconds;
    }

    public static long DateTimeToMilliSeconds(DateTime t)
    {
        return (long) (t.ToUniversalTime() - UnixEpoch).TotalMilliseconds;
    }

    public static DateTime MilliSecondsToDateTime(long milliSeconds)
    {
        return UnixEpoch.AddMilliseconds(milliSeconds).ToLocalTime();
    }

    public static DateTime SecondsToDateTime(long seconds)
    {
        return UnixEpoch.AddSeconds(seconds).ToLocalTime();
    }
}

[TestFixture]
public class DateTimeTest
{
    [SetUp]
    public void Prepare()
    {
        Console.WriteLine("prepare ready");
    }

    int getCurrentSecond()
    {
        var x = (DateTime.UtcNow - DateTime.UnixEpoch).TotalSeconds;
        return (int) x;
    }

    int getCurrentSecond2()
    {
        var x = (DateTime.Now - DateTime.UnixEpoch.ToLocalTime()).TotalSeconds;
        return (int) x;
    }

    int getCurrentSecond3()
    {
        return (int) (DateTime.Now - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
    }

    int getCurrentSecond4()
    {
        var x = (DateTime.Now.ToUniversalTime() - DateTime.UnixEpoch).TotalSeconds;
        return (int) x;
    }

    [Test]
    public void testGetCurrentSeconds()
    {
        Console.WriteLine($@"
getCurrentSecond={getCurrentSecond()}
getCurrentSecond2={getCurrentSecond2()}
getCurrentSecond3={getCurrentSecond3()}
getCurrentSecond4={getCurrentSecond4()}
Util.GetUtcSeconds={Util.GetUtcSeconds()}
");
    }

    [Test]
    public void testToUniversal()
    {
        Console.WriteLine($@"
{DateTime.Now.ToUniversalTime()}
{DateTime.Now.ToLocalTime()}
{DateTime.UtcNow.ToUniversalTime()}
{DateTime.UtcNow.ToLocalTime()}
{new DateTime(1970, 1, 1)}
{new DateTime(1970, 1, 1).ToUniversalTime()}
{new DateTime(1970, 1, 1).ToLocalTime()}
{new DateTime(1970, 1, 1).ToLocalTime().ToLocalTime()}
");
    }

    [Test]
    public static void TestUnixEpoch()
    {
        Console.WriteLine($@"
{DateTime.UnixEpoch}
{new DateTime(1970, 1, 1).ToLocalTime().ToUniversalTime()}

将时间转成UTC的时候，会减去8个小时
{TimeZoneInfo.ConvertTimeToUtc(new DateTime(1970, 1, 1))}
{new DateTime(1970, 1, 1).ToUniversalTime()}
");
    }

    [Test]
    public void testToLocalTime()
    {
        var x = new DateTime(1970, 1, 1);
        Console.WriteLine(@$"
{TimeZone.CurrentTimeZone.ToLocalTime(x)} 01/01/1970 08:00:00
{x.ToLocalTime()} 01/01/1970 08:00:00
{x.ToUniversalTime()} 12/31/1969 16:00:00
{DateTime.UnixEpoch == new DateTime(1970)} False
{DateTime.UnixEpoch == x} True
{DateTime.UnixEpoch.ToLocalTime() == x.ToLocalTime()} True
{DateTime.UnixEpoch.ToUniversalTime() == x.ToUniversalTime()} False
{TimeZone.CurrentTimeZone.ToLocalTime(x)}01/01/1970 08:00:00
{DateTime.UnixEpoch == TimeZone.CurrentTimeZone.ToLocalTime(x)} False 
{DateTime.UnixEpoch == TimeZone.CurrentTimeZone.ToLocalTime(x).ToUniversalTime()} True
{DateTime.UnixEpoch == TimeZoneInfo.ConvertTime(x, TimeZoneInfo.Utc)} False {TimeZoneInfo.ConvertTime(x, TimeZoneInfo.Utc)}
{DateTime.UnixEpoch == new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)}
");
    }

    [Test]
    public void DontUseTimeZone()
    {
        /*
         * 不要使用TimeZone，TimeZone已经废弃。
         * 而要使用TimeZoneInfo
         */
        var x = new DateTime(1970, 1, 1);
        Console.Write($@"
{TimeZone.CurrentTimeZone.ToLocalTime(x)}
{TimeZoneInfo.ConvertTime(x, TimeZoneInfo.Local)}
{TimeZoneInfo.ConvertTime(x, TimeZoneInfo.Utc)}
");
    }

    [Test]
    public void testOne()
    {
        var timeStart = new DateTime(1970, 1, 1);
        Console.WriteLine($@"
起始时间：{timeStart}
Unix起始时间在本地时间：{DateTime.UnixEpoch.ToLocalTime()}
Unix起始时间在本地时间（多次转换时间不变，DateTime是带有时区信息的）：{DateTime.UnixEpoch.ToLocalTime().ToLocalTime()}
getCurrentSecond:{getCurrentSecond()}
getCurrentSecond2:{getCurrentSecond2()}
getCurrentSecond3:{getCurrentSecond3()}
最小时间：{DateTime.MinValue}
最大时间：{DateTime.MaxValue}
今天时间Now：{DateTime.Now}
今天时间Today：{DateTime.Today}
UnixEpoch:{DateTime.UnixEpoch}
UTCNow:{DateTime.UtcNow}
");
        TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        TimeSpan tsUtc = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        var tt = Convert.ToInt64(ts.TotalSeconds);
        Console.WriteLine($"C#侧的时间：Now={tt} UTC_Now={Convert.ToInt64(tsUtc.TotalSeconds)}");
        Console.WriteLine("休息三秒");
    }
}